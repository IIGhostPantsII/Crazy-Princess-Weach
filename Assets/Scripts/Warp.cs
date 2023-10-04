using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string _sceneName;
    [SerializeField] private GameObject _white;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioSource _musicManager;

    bool _triggered = false;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!_triggered)
            {
                Globals.AdvanceLevel();
                _triggered = true;
                Globals.Death();
                _white.SetActive(true);
                _musicManager.Stop();
                _soundManager._source.PlayOneShot(_soundManager._clips[2]);
                StartCoroutine(LoadLevel());
            }
        }
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(_sceneName);
    }
}
