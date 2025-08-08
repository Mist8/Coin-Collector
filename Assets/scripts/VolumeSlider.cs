using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    void Start()
    {
        //load saved values or default to 1
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

        //optionally, you can also set AudioListener.volume for overall sound
        AudioListener.volume = master;
    }
}