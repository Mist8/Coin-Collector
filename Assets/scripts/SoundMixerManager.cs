using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; //manages the sound mixer settings in Unity, allowing for audio adjustments and management

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";

        public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*masterSlider.SetValueWithoutNotify(1f);
    musicSlider.SetValueWithoutNotify(1f);
    sfxSlider.SetValueWithoutNotify(1f);
        Debug.Log(masterSlider);*/

        /*masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;*/

        /*audioMixer.SetFloat("masterVolume", 0f); //Set the master volume to 0 (max) at the start
        audioMixer.SetFloat("musicVolume", 0f);
        audioMixer.SetFloat("soundFXVolume", 0f);*/

        /*SetMasterVolume(1f);
        SetMusicVolume(1f);
        SetSoundFXVolume(1f);*/

        //LOAD SAVED VALUES or default to 1
        masterSlider.value = PlayerPrefs.GetFloat(MasterKey, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(MusicKey, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SFXKey, 1f);

        //apply volumes on start
        UpdateVolumes();

        //listen for slider changes
        masterSlider.onValueChanged.AddListener(delegate { OnMasterVolumeChanged(); });
        musicSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChanged(); });
        sfxSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChanged(); });
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
    
        void OnMasterVolumeChanged()
    {
        PlayerPrefs.SetFloat(MasterKey, masterSlider.value);
        PlayerPrefs.Save();
        UpdateVolumes();
    }

    void OnMusicVolumeChanged()
    {
        PlayerPrefs.SetFloat(MusicKey, musicSlider.value);
        PlayerPrefs.Save();
        UpdateVolumes();
    }

    void OnSFXVolumeChanged()
    {
        PlayerPrefs.SetFloat(SFXKey, sfxSlider.value);
        PlayerPrefs.Save();
        UpdateVolumes();
    }

    void UpdateVolumes()
    {
        //apply master volume combined with music/SFX volumes
        float master = masterSlider.value;

        if (musicAudioSource != null)
            musicAudioSource.volume = master * musicSlider.value;

        if (sfxAudioSource != null)
            sfxAudioSource.volume = master * sfxSlider.value;

        //set AudioListener.volume for overall sound
        AudioListener.volume = master;
    }
}
