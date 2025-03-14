using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) // Use OnCollisionEnter for 3D
    {
        // Check if the player collided with the monster
        if (collision.gameObject.CompareTag("movingmonster"))
        {
            // Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}