using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public float fadeTime = 7.0f;
    private AudioSource audioSource;
    private AudioClip[] clips;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clips = new AudioClip[] { audioSource.clip, audioSource.clip };
        audioSource.clip = clips[currentClipIndex];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(FadeToNextClip());
        }
    }

    IEnumerator FadeToNextClip()
    {
        float t = 0.0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);
            yield return null;
        }
        currentClipIndex = (currentClipIndex + 1) % clips.Length;
        audioSource.clip = clips[currentClipIndex];
        audioSource.Play();
        t = 0.0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0.0f, 1.0f, t / fadeTime);
            yield return null;
        }
    }
}
