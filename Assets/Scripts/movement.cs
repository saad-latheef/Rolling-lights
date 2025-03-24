using UnityEngine;

public class SmoothPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float smoothTime = 0.1f; // Time to smooth the movement
    public AudioClip movementSound; // Sound effect for movement

    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        // Add an AudioSource component for playing sounds
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = movementSound;
        audioSource.loop = true; // Loop the sound for continuous movement
    }

    void Update()
    {
        // Input handling (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector2 movement = new Vector2(moveX, moveY);

        // Normalize diagonal movement
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Apply movement with smoothing
        Vector2 targetVelocity = movement * moveSpeed;
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Check if the player is moving and play sound accordingly
        if (movement.magnitude > 0)
        {
            if (!isMoving)
            {
                isMoving = true;
                audioSource.Play(); // Start playing the movement sound
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                audioSource.Stop(); // Stop the sound when movement stops
            }
        }
    }
}
