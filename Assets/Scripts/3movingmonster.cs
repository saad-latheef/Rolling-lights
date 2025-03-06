using UnityEngine;

public class monstermovment3 : MonoBehaviour
{
    public float speed = 2f; // Speed of movement
    public float distance = 5f; // Distance to move
    public bool moveOnXAxis = true; // Toggle between X and Y axis movement
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Save the starting position
    }

    void Update()
    {
        // Move the monster back and forth along the chosen axis
        if (moveOnXAxis)
        {
            float newX = startPosition.x + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else
        {
            float newY = startPosition.y + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}