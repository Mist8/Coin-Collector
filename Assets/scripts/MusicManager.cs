using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;
    public float fadeDuration = 1.5f; // seconds for fade

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this GameObject persists
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void FadeMusic()
    {
        StartCoroutine(FadeEffect());
    }

    public IEnumerator FadeEffect()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        float startVolume = audioSource.volume;
        float t = 0f;

        //Fade out
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();


        // Switch to new clip at full volume
        /*audioSource.clip = newClip;
        audioSource.volume = startVolume;
        audioSource.Play();*/
    }

    public void PlayMusic(AudioClip newClip, float volume)
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        audioSource.clip = newClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
