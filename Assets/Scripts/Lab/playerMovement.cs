using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 50.0f;
    public float jumpForce = 10.0f;
    public float gravityMult = 5.0f;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * speed);
        }

        if(!isGrounded)
        {
            rigidbody.AddForce(Physics.gravity * gravityMult, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if(ground)
        {
            isGrounded = true;
            Debug.Log("is on the ground");
        }
    }

    void OnCollisionExit(Collision other)
    {
        Ground ground = other.gameObject.GetComponent<Ground>();
        if(ground)
        {
            isGrounded = false;
            Debug.Log("is on the air");
        }
    }
}
