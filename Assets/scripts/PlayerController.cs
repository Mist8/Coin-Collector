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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal"); //left/right arrow keys or A/D keys
        yInput = Input.GetAxis("Vertical"); //up/down arrow keys or W/S keys (i think its front/back)

        if (transform.position.y < -5f) //if the player falls below a certain height
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
        }

    }

    private void FixedUpdate()
    {
        /*rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed); //apply force to the rigidbody based on input

        float horizontalInput = Input.GetAxis("Horizontal"); //left/right arrow keys or A/D keys
        float verticalInput = Input.GetAxis("Vertical"); //up/down arrow keys or W/S keys (i think its front/back)*/

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

        // Move the character
        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinsCollected++;
            other.gameObject.SetActive(false); //deactivate the coin object
        }

        if(other.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene if player hits a spike
        }

        if (coinsCollected >= 7) //win game
        {
            winText.SetActive(true); //activate the win text
            //Time.timeScale = 0; //pause the game
        }

    }
}
