using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _source;
    public AudioClip[] _clips;
    public AudioClip[] _music;

    public static SoundManager _instance;

    public void PlayMusic(int musicIndex)
    {
        _source.Stop();
        _source.clip = _music[musicIndex];
        _source.loop = true;
        _source.volume = 1;
        _source.time = 0; // set the time of the audio source to the start time
        _source.Play();
    }

    public void FadeOutAudio(float fadeDuration)
    {
        StartCoroutine(FadeOutCoroutine(fadeDuration));
    }

    private IEnumerator FadeOutCoroutine(float fadeDuration)
    {
        float startVolume = _source.volume;
        float startTime = Time.time;

        while (Time.time - startTime < fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            _source.volume = Mathf.Lerp(startVolume, 0f, t);
            yield return null;
        }

        _source.volume = 0f;
    }
}
