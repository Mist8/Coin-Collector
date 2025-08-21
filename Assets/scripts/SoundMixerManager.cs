using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; //manages the sound mixer settings in Unity, allowing for audio adjustments and management

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*masterSlider.SetValueWithoutNotify(1f);
    musicSlider.SetValueWithoutNotify(1f);
    sfxSlider.SetValueWithoutNotify(1f);
        Debug.Log(masterSlider);*/

        masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;

        /*audioMixer.SetFloat("masterVolume", 0f); //Set the master volume to 0 (max) at the start
        audioMixer.SetFloat("musicVolume", 0f);
        audioMixer.SetFloat("soundFXVolume", 0f);*/

        SetMasterVolume(1f);
        SetMusicVolume(1f);
        SetSoundFXVolume(1f);
    }

    // Update is called once per frame
    void Update()
    {

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
