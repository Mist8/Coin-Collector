using UnityEngine;
using TMPro;


public class EndScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultsText;

    void Start()
    {
        LevelTimer.instance.resultsText = resultsText;
        LevelTimer.instance.ShowResults();
    }

}
