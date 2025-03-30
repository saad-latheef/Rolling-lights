using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class movementofghost : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float moveDistance = 3f; // Distance to move left and right

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        // Save the starting position of the ghost
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the target position based on direction
        Vector3 targetPosition = movingRight ? startPosition + Vector3.right * moveDistance : startPosition - Vector3.right * moveDistance;

        // Move the ghost towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the ghost has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Reverse direction
            movingRight = !movingRight;
        }
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