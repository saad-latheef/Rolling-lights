using UnityEngine;

public class obstacleMonsterOnTrigger : MonoBehaviour
{
    public GameObject monster; // Reference to the monster GameObject
    public Vector3 moveOffset; // How far to move the monster

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip moveSound;     // Sound when the monster moves
    public AudioClip returnSound;   // Sound when the monster returns

    private Vector3 originalPosition; // Store the monster's original position
    private bool isMoved = false; // Flag to track the monster's current state

    private void Start()
    {
        // Store the monster's original position at the start
        if (monster != null)
        {
            originalPosition = monster.transform.position;

            // Automatically get the AudioSource component from the monster
            audioSource = monster.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on the monster!");
            }
        }
        else
        {
            Debug.LogError("Monster GameObject is not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the box
        if (other.CompareTag("Player"))
        {
            ToggleMonsterMovement();
        }
    }

    private void OnMouseDown()
    {
        // Handle mouse/touch input to toggle monster movement
        ToggleMonsterMovement();
    }

    public void ToggleMonsterMovement()
    {
        if (monster != null)
        {
            // Toggle the monster's position
            if (isMoved)
            {
                // Move the monster back to its original position
                monster.transform.position = originalPosition;
                Debug.Log("Monster moved back to original position!");

                // Play the return sound effect
                if (returnSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(returnSound);
                }
            }
            else
            {
                // Move the monster by the specified offset
                monster.transform.position = originalPosition + moveOffset;
                Debug.Log("Monster moved to new position!");

                // Play the move sound effect
                if (moveSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(moveSound);
                }
            }

            // Toggle the flag
            isMoved = !isMoved;
        }
        else
        {
            Debug.LogError("Monster GameObject is not assigned!");
        }
    }
}