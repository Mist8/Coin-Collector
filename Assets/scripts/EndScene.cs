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
 
        if (MusicManager.instance != null)
        {
            if (MusicManager.instance.GetComponent<AudioSource>().clip != endSound)
            {
                MusicManager.instance.SwitchMusic(endSound);
            }
        }

    }
}
