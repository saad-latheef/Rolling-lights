using UnityEngine;

public class DisableMovementOnEnter : MonoBehaviour
{
    public float movementDisableDuration = 1f; // Duration to disable movement (in seconds)
    private bool hasTriggered = false; // Flag to track if the script has already been triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered) // Ensure your ball has the tag "Player" and the script hasn't been triggered yet
        {
            hasTriggered = true; // Mark the script as triggered
            DisableBallMovement(other.gameObject);
            Invoke(nameof(EnableBallMovement), movementDisableDuration);
        }
    }

    private void DisableBallMovement(GameObject ball)
    {
        // Disable the SmoothPlayerMovement script
        SmoothPlayerMovement movementScript = ball.GetComponent<SmoothPlayerMovement>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
            Debug.Log("Ball movement disabled.");
        }

        // Reset Rigidbody2D velocity to stop any existing movement
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Ball velocity reset.");
        }
    }

    private void EnableBallMovement()
    {
        // Re-enable the SmoothPlayerMovement script
        GameObject ball = GameObject.FindGameObjectWithTag("Player"); // Find the ball object
        if (ball != null)
        {
            SmoothPlayerMovement movementScript = ball.GetComponent<SmoothPlayerMovement>();
            if (movementScript != null)
            {
                movementScript.enabled = true;
                Debug.Log("Ball movement re-enabled.");
            }
        }
    }
}