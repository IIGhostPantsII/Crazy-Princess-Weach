using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gant : MonoBehaviour
{
    public SoundManager _soundManager;
    public GameObject _gant;

    bool _itsOn;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!_itsOn)
            {
                _itsOn = true;
                _soundManager.FadeOutAudio(3f);
                StartCoroutine(PlayMusic());
            }
        }
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(Random.Range(4.5f, 7f));
        //RELEASE THE KRAKEN
        _soundManager.PlayMusic(16);
        _gant.SetActive(true);
        Destroy(gameObject);
    }
}
