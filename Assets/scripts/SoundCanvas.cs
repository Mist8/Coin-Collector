using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundCanvas : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    //private bool initialized = false;
    public SoundMixerManager mixerManager;
    public GameObject panelOrCanvas; //panel OR canvas GameObject that will be opened/closed

    private void Start()
    {
        if (panelOrCanvas != null) //hide panel/canvas on game start
        {
            panelOrCanvas.SetActive(false);
        }
        /*masterSlider.SetValueWithoutNotify(1f);
        musicSlider.SetValueWithoutNotify(1f);
        sfxSlider.SetValueWithoutNotify(1f);
        initialized = false;*/

        /*masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;

        mixerManager.SetMasterVolume(1f);
        mixerManager.SetMusicVolume(1f);
        mixerManager.SetSoundFXVolume(1f); */
    }
    /*private void OnEnable()
    {

        if (!initialized)
        {
            masterSlider.value = 1f;
            musicSlider.value = 1f;
            sfxSlider.value = 1f;

            mixerManager.SetMasterVolume(1f);
            mixerManager.SetMusicVolume(1f);
            mixerManager.SetSoundFXVolume(1f);

            masterSlider.value = 1f;
            musicSlider.value = 1f;
            sfxSlider.value = 1f;

            initialized = true;
        }
    } */
}
