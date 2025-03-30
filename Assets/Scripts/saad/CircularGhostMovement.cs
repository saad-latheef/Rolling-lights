using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class CircularGhostMovement : MonoBehaviour
{
    public float radius = 3f; // Radius of the circular path
    public float speed = 2f; // Speed of movement

    private Vector3 centerPosition; // Center of the circle
    private float angle = 0f; // Current angle in radians

    void Start()
    {
        // Save the starting position as the center of the circle
        centerPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position using circular motion formula
        angle += speed * Time.deltaTime; // Increment the angle based on speed and time
        float x = centerPosition.x + Mathf.Cos(angle) * radius; // X position
        float y = centerPosition.y + Mathf.Sin(angle) * radius; // Y position

        // Update the ghost's position
        transform.position = new Vector3(x, y, transform.position.z);
    }

    // Detect collisions with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            ResetGame(); // Reset the game
        }
    }

    private void ResetGame()
    {
        // Reload the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}   