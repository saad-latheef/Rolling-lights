using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MasterSoldierMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement (customizable for master)
    public float moveDistance = 2f; // Distance to move up and down (customizable for master)
    public GameObject slaveSoldier; // Reference to the slave soldier

    private Vector2 startPosition;
    private bool movingUp = true;

    private void Start()
    {
        startPosition = transform.position; // Store the starting position of the master
    }

    private void Update()
    {
        // Move the master soldier up and down
        if (movingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition + Vector2.up * moveDistance, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPosition + Vector2.up * moveDistance) < 0.01f)
            {
                movingUp = false; // Switch direction when reaching the top
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPosition) < 0.01f)
            {
                movingUp = true; // Switch direction when reaching the bottom
            }
        }

        // Update the slave soldier's position to move in the opposite direction
        if (slaveSoldier != null)
        {
            SlaveSoldierMovement slaveScript = slaveSoldier.GetComponent<SlaveSoldierMovement>();
            if (slaveScript != null)
            {
                slaveScript.MoveOpposite(movingUp, moveSpeed, moveDistance);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure your ball has the tag "Player"
        {
            ResetLevel();
        }
    }

    private void ResetLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Level reset: Ball touched a soldier.");
    }
}