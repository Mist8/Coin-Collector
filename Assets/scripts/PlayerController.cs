using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for scene management

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    float xInput;
    float yInput;

    Rigidbody rb;

    public GameObject winText;
    private Camera mainCamera;

    int coinsCollected;
    bool finishedLevel;
    //[SerializeField] private AudioClip coinSound; // sound to play when collecting a coin
    public AudioClip coinSound;
    public AudioClip spikeSound;
    public AudioClip winSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        finishedLevel = false;
        coinsCollected = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal"); //left/right arrow keys or A/D keys
        yInput = Input.GetAxis("Vertical"); //up/down arrow keys or W/S keys (i think its front/back)

        if (transform.position.y < -5f && !finishedLevel) //if the player falls below a certain height
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
        }

    }

    private void FixedUpdate()
    {
        // Get camera's forward and right vectors (without y)
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction
        Vector3 moveDirection = forward * yInput + right * xInput;

        rb.AddForce(moveDirection * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finishedLevel) return;

        if (other.tag == "Coin")
        {
            coinsCollected++;
            SoundFXManager.instance.PlaySoundFXClip(coinSound, transform, 1f); //play coin sound effect
            other.gameObject.SetActive(false); //deactivate the coin object
        }

        if (other.tag == "Spike")
        {
            SoundFXManager.instance.PlaySoundFXClip(spikeSound, transform, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene if player hits a spike


        }

        if (coinsCollected >= 8 && SceneManager.GetActiveScene().buildIndex == 1) //win level 2
        {
            StartCoroutine(LoadLevel(2));

        }
        if (coinsCollected >= 18 && SceneManager.GetActiveScene().buildIndex == 2) //win level 3
        {
            StartCoroutine(LoadLevel(3));
        }
        if (coinsCollected >= 4 && SceneManager.GetActiveScene().buildIndex == 0) //win level 1
        {
            StartCoroutine(LoadLevel(1));
        }
        if (coinsCollected >= 12 && SceneManager.GetActiveScene().buildIndex == 3) //win level 4
        {
            StartCoroutine(LoadLevel(4));
        }
        if (coinsCollected >= 13 && SceneManager.GetActiveScene().buildIndex == 4) //win level 5
        {
            StartCoroutine(LoadLevel(4));
        }

    }
    IEnumerator LoadLevel(int sceneIndex)
    {
        finishedLevel = true;
        SoundFXManager.instance.PlaySoundFXClip(winSound, transform, 1f);
        winText.SetActive(true);
        yield return new WaitForSeconds(4f); // wait for text to show
        SceneManager.LoadScene(sceneIndex);
        finishedLevel = false;
    }
}
