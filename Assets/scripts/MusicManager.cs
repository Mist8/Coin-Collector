using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    //public AudioSource musicObject; // Prefab for the audio source

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this GameObject persists
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
