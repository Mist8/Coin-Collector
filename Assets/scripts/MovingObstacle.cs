using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 pointA; //First point to move to
    public Vector3 pointB; //Second point to move to
    public float speed = 1.0f; //movement speed

    private Vector3 lastPosition; //previous frame position
    private int randomIndex;
    private float phaseOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
        phaseOffset = Random.Range(0f, 1f);

        //If startPosition is not pointA or pointB, pick random first target
        if (startPosition != pointA && startPosition != pointB)
        {
            int randomIndex = Random.Range(0, 2);
            transform.position = startPosition;
            if (randomIndex == 0)
                transform.position = pointA;
            else
                transform.position = pointB;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed + phaseOffset, 1f);
        transform.position = Vector3.Lerp(pointA, pointB, t);

        // Calculate movement direction
        Vector3 moveDir = transform.position - lastPosition;
        moveDir.y = 0; // optional: keep object upright
        //moveDir.Normalize(); //if only care abt direction, not distance when rotating

        //face direction of movement
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        lastPosition = transform.position; // update last position for next frame
        
    }
}
