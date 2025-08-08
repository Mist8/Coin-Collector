using UnityEngine;
using UnityEngine.Audio; //manages the sound mixer settings in Unity, allowing for audio adjustments and management

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioMixer.SetFloat("masterVolume", 0f); // Set the master volume to 0 at the start
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake() //not sure
    {
            DontDestroyOnLoad(this.gameObject);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20f); // Set the master volume to the specified value
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20f);
    }
    
    public void SetSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(volume) * 20f);
    }
}
