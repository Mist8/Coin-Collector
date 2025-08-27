using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer instance; // Singleton instance - make sure only one exists & makes methods static/globally accessible
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultsText;
    public float elapsedTime = 0f;
    private bool isRunning = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; //adds secs since last frame

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 10f) % 10f);

            timerText.text = string.Format("{0:00}:{1:00}.{2}", minutes, seconds, milliseconds);
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void SaveLevelTime(int levelIndex, float time)
    {
        PlayerPrefs.SetFloat("LevelTime_" + levelIndex, time);
        PlayerPrefs.Save();
    }

    public float GetLevelTime(int levelIndex)
    {
        return PlayerPrefs.GetFloat("LevelTime_" + levelIndex, -1f); //Returns -1 if no time is recorded
    }
    
    public void ShowResults()
    {   
        resultsText.text += "Completion Times:\n\n";
        for (int i = 1; i <= 5; i++)
        {
            float time = PlayerPrefs.GetFloat("LevelTime_" + i, -1f);

            if (time >= 0f)
            {
                int minutes = Mathf.FloorToInt(time / 60f);
                int seconds = Mathf.FloorToInt(time % 60f);
                int milliseconds = Mathf.FloorToInt((time * 10f) % 10f);
                Debug.Log("Level " + i + ": " + string.Format("{0:00}:{1:00}", minutes, seconds));
                resultsText.text += "Level " + i + ": " +
                    string.Format("{0:00}:{1:00}.{2}", minutes, seconds, milliseconds) + "\n" + "\n";
            }
            else
            {
                Debug.Log("Level " + i + " not completed");
            }
        }
    }
}