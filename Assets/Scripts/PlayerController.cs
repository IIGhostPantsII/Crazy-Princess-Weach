using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 800f;
    [SerializeField] private float _jumpForce = 15f;
    public float _mouseSensitivity = 5f;
    [SerializeField] private float _groundCheckRadius = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private BulletShooter _bulletShooter;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private Menu _menuScript;

    //Menu Prefab
    [SerializeField] public GameObject _menu;

    //INPUT BOOLS
    private bool _isSprinting;
    private bool _isJumping;
    private bool _isGrounded = true;
    private bool _isShooting;
    private bool _isDashing;
    private bool _isReloading;
    public bool _menuBool;

    //Using Unitys new input system
    PlayerInput _input;

    private Rigidbody _playerRigidbody;

    //Rotation - used for mouse input
    float _xRotation = 0f;

    bool _delay;
    bool _dashDelay;
    public bool _shootDelay;
    public bool _reload;
    public bool _noAni;
    bool _startFalling;

    public int _ammo;
    private int _groundedCount = 0; // Track the number of grounded colliders

    public Animator _playerAni;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //INPUT VALUES
        _isJumping = _input.Player.Jump.ReadValue<float>() > 0.1f;
        _isSprinting = _input.Player.Sprint.ReadValue<float>() > 0.1f;
        _isShooting = _input.Player.Fire.ReadValue<float>() > 0.1f;
        _isDashing = _input.Player.Dash.ReadValue<float>() > 0.1f;
        _isReloading = _input.Player.Reload.ReadValue<float>() > 0.1f;

        if(_isJumping && !_delay && _isGrounded)
        {
            StartCoroutine(InputDelay(0.15f));
            _delay = true;
            StartCoroutine(Jump());
            _startFalling = false;
        }

        if(_isReloading)
        {
            _ammo = 0;
        }

        if(_isShooting && !_shootDelay && !_reload && !_noAni && !Globals.DeathScreen)
        {
            _ammo--;
            StartCoroutine(ShootDelay(Globals.FireRate));
            _shootDelay = true;
            _soundManager._source.PlayOneShot(_soundManager._clips[0]);
            _bulletShooter.ShootBullet();
        }
        else if(_isShooting && !_reload && !_noAni)
        {
            
        }
        else
        {
            
        }

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Screen.dpi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Screen.dpi * Time.deltaTime;


        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    void FixedUpdate()
    {
        float horizontal = _input.Player.Move.ReadValue<Vector2>().x;
        float vertical = _input.Player.Move.ReadValue<Vector2>().y;

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement.y = 0;

        if(_isSprinting)
        {
            movement *= Globals.Speed;
        }

        if(_isDashing && !_dashDelay && movement.magnitude > 0)
        {
            StartCoroutine(InputDelayDash(3.0f));
            _dashDelay = true;
            StartCoroutine(Dash(movement));
        }

        if(!_isGrounded && _startFalling)
        {
            _playerRigidbody.AddForce(Physics.gravity * 100.0f, ForceMode.Acceleration);
        }

        if(movement.magnitude > 0)
        {
            _playerAni.Play("Move");
        }
        else
        {
            _playerAni.Play("Idle");
        }

        _playerRigidbody.velocity = movement * _speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    IEnumerator InputDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _delay = false;
    }

    IEnumerator InputDelayDash(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _dashDelay = false;
    }

    public IEnumerator ShootDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _shootDelay = false;
    }

    IEnumerator Dash(Vector3 soTrue)
    {
        for(int i = 20; i < 40; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _playerRigidbody.AddForce(soTrue.normalized * i, ForceMode.Impulse);
        }
    }

    IEnumerator Jump()
    {
        for(int i = 1; i < _jumpForce; i++)
        {
            yield return new WaitForSeconds(0.0005f * i);
            _playerRigidbody.AddForce(Vector3.up * i, ForceMode.Impulse);
            _startFalling = false;
        }
        _startFalling = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundedCount++;
            UpdateGroundedState();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundedCount--;
            UpdateGroundedState();
        }
    }

    private void UpdateGroundedState()
    {
        _isGrounded = _groundedCount > 0;
        _startFalling = !_isGrounded;
    }
}