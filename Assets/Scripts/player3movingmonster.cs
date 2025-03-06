using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) // Use OnCollisionEnter for 3D
    {
        // Check if the player collided with the monster
        if (collision.gameObject.CompareTag("3movingmonster"))
        {
            // Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}