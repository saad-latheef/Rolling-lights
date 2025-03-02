using UnityEngine;
using UnityEngine.SceneManagement;
public class SlaveSoldierMovement : MonoBehaviour
{
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Store the starting position of the slave
    }

    public void MoveOpposite(bool masterMovingUp, float masterMoveSpeed, float masterMoveDistance)
    {
        // Move the slave soldier in the opposite direction of the master
        if (masterMovingUp)
        {
            // Master is moving up, so slave moves down
            transform.position = Vector2.MoveTowards(transform.position, startPosition, masterMoveSpeed * Time.deltaTime);
        }
        else
        {
            // Master is moving down, so slave moves up
            transform.position = Vector2.MoveTowards(transform.position, startPosition + Vector2.up * masterMoveDistance, masterMoveSpeed * Time.deltaTime);
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