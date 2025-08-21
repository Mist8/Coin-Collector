using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VolumeManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public bool firstLevel1Load;

    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";
    private const string FirstTimeKey = "FirstTimeLoad";

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;
   

    void Start()
    {
        bool isFirstTime = PlayerPrefs.GetInt(FirstTimeKey, 1) == 1;

        if (SceneManager.GetActiveScene().buildIndex != 0 || !isFirstTime) //not level 1 OR first lvl 1 load
        {
            //LOAD SAVED VALUES or default to 1
            masterSlider.value = PlayerPrefs.GetFloat(MasterKey, 1f);
            musicSlider.value = PlayerPrefs.GetFloat(MusicKey, 1f);
            sfxSlider.value = PlayerPrefs.GetFloat(SFXKey, 1f);

            //apply volumes on start
            UpdateVolumes();

        }
        else //first time loading game
        {
            //First time in Level 1: reset all sliders to 100%
            masterSlider.value = 1f;
            musicSlider.value = 1f;
            sfxSlider.value = 1f;

            UpdateVolumes();

            // mark that we already loaded Level 1 once
            PlayerPrefs.SetInt(FirstTimeKey, 0);
            PlayerPrefs.Save();
        }

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

        //set AudioListener.volume for overall sound
        AudioListener.volume = master;
    }
}