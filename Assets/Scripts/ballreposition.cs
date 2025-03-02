using UnityEngine;

public class BallReposition : MonoBehaviour
{
    public Vector3 respawnPosition; // Position to respawn the ball (now includes Z-axis)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soldier")) // Ensure your soldiers have the tag "Soldier"
        {
            RepositionBall();
        }
    }

    private void RepositionBall()
    {
        // Move the ball to the respawn position, including the Z-axis
        transform.position = respawnPosition;
        Debug.Log("Ball repositioned to: " + respawnPosition); // Debug log for repositioning
    }
}