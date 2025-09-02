using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    /*public float rotationSpeed = 0.5f; //degrees per second

    void Update()
    {
        //Rotate the skybox
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }*/

    float currentRotation = 0f;
    public float rotationSpeed;
    void Update()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation", currentRotation);
    }
}