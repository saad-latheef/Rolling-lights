using UnityEngine;

public class MoveGreenMonsterOnTrigger : MonoBehaviour
{
    public GameObject greenmonster; // Reference to the monster GameObject
    public Vector3 moveOffset; // How far to move the monster

    private Vector3 originalPosition; // Store the monster's original position
    private bool isMoved = false; // Flag to track the monster's current state

    private void Start()
    {
        // Store the monster's original position at the start
        if (greenmonster != null)
        {
            originalPosition = greenmonster.transform.position;
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
            if (greenmonster != null)
            {
                // Toggle the monster's position
                if (isMoved)
                {
                    // Move the monster back to its original position
                    greenmonster.transform.position = originalPosition;
                    Debug.Log("Monster moved back to original position!");
                }
                else
                {
                    // Move the monster by the specified offset
                    greenmonster.transform.position = originalPosition + moveOffset;
                    Debug.Log("Monster moved to new position!");
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
}