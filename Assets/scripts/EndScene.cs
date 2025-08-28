using UnityEngine;
using TMPro;


public class EndScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultsText;
    public AudioClip endSound;


    void Start()
    {
        LevelTimer.instance.resultsText = resultsText;
        LevelTimer.instance.ShowResults();
        if (SoundFXManager.instance != null)
        {
            SoundFXManager.instance.PlaySoundFXClip(endSound, null, 1f);
        }
        

    }
}
