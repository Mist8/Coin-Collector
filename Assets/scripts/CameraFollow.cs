using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //the target to follow
    Vector3 offset; //the offset from the target
    //private PanelOpener panelOpener;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position; //calculate the initial offset btwn camera & target
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; //set camera position to the target position plus the offset

        float rotateHorizontal = Input.GetAxis("Mouse X"); //get horizontal mouse movement

        if (!PanelOpener.paused)
        {
            transform.RotateAround(target.position, Vector3.up, rotateHorizontal * 4.5f); //rotate camera around the y-axis based on horizontal mouse movement

            // Update the offset after rotation
            offset = transform.position - target.position;
        }
    }
}
