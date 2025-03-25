using UnityEngine;

public class SmoothPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float smoothTime = 0.1f; // Time to smooth the movement

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input handling (WASD)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

        // Create a movement vector
        Vector2 movement = new Vector2(moveX, moveY);

        // Normalize the vector to prevent faster diagonal movement
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Apply movement to the Rigidbody2D with smoothing
        Vector2 targetVelocity = movement * moveSpeed;
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, smoothTime);
    }
}
