using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    //[SerializeField] private AudioSource soundFXObject; // Prefab for the audio source
    public AudioSource soundFXObject; // Prefab for the audio source
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    public void PlaySoundFXClip(AudioClip audioclip, Transform spawnTransform, float volume)
    {
        //AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        Vector3 spawnPos = spawnTransform != null ? spawnTransform.position : Vector3.zero;
        AudioSource audioSource = Instantiate(soundFXObject, spawnPos, Quaternion.identity);
        DontDestroyOnLoad(audioSource.gameObject); //keep object across scene loads

        audioSource.clip = audioclip; // Set the audio clip
        audioSource.volume = volume; // Set the volume
        audioSource.Play(); // Play the sound effect

        float clipLength = audioSource.clip.length; // Get the length of the audio clip
        Destroy(audioSource.gameObject, clipLength); // Destroy the audio source after the clip finishes playing
    }
}
