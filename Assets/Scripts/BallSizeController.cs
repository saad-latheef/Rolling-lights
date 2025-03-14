using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    private Vector3 originalScale; // Store the original size of the ball
    public float shrinkScale = 2f; // Scale when the ball shrinks

    void Start()
    {
        // Save the original scale of the ball
        originalScale = transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the ball collides with the "Shrink Box"
        if (other.CompareTag("ShrinkBox"))
        {
            // Shrink the ball
            transform.localScale = originalScale * shrinkScale;
        }

        // Check if the ball collides with the "Grow Box"
        if (other.CompareTag("GrowBox"))
        {
            // Return the ball to its original size
            transform.localScale = originalScale;
        }
    }
}