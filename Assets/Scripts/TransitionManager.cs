using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{

    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private SoundManager _soundManager;

    bool _buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
        if(Globals.CurrentLevel < 3)
        {
            _soundManager.PlayMusic(0);
        }
        else if(Globals.CurrentLevel > 2 && Globals.CurrentLevel < 6)
        {
            _soundManager.PlayMusic(1);
        }
        else if(Globals.CurrentLevel > 5 && Globals.CurrentLevel < 8)
        {
            _soundManager.PlayMusic(2);
        }
    }

    public void FireRateButton()
    {
        if(!_buttonPressed)
        {
            _buttonPressed = true;
            _menuAnimator.Play("MenuFadeOut");
            _soundManager._source.Stop();
            _soundManager._source.PlayOneShot(_soundManager._clips[0]);
            Globals.AddFireRate();
            StartCoroutine(LoadLevel());
        }
    }

    public void SpeedButton()
    {
        if(!_buttonPressed)
        {
            _buttonPressed = true;
            _menuAnimator.Play("MenuFadeOut");
            _soundManager._source.Stop();
            _soundManager._source.PlayOneShot(_soundManager._clips[0]);
            Globals.AddSpeed();
            StartCoroutine(LoadLevel());
        }
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Level1");
    }
}
