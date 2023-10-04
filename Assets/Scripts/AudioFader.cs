using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 1.0f;
    public float targetVolume = 1.0f;

    private float initialVolume;
    private float startTime;

    private bool isFading = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
            enabled = false; // Disable the script if no AudioSource is found.
        }

        StartFadeIn();
    }

    private void Update()
    {
        if (isFading)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, t);

            if (t >= 1.0f)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeIn()
    {
        if (audioSource != null)
        {
            initialVolume = audioSource.volume;
            startTime = Time.time;
            isFading = true;
        }
    }
}
