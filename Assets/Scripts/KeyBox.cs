using UnityEngine;

public class KeyBox : MonoBehaviour
{
    public DoorController door; // Assign the door in the Inspector
    private bool hasOpened = false; // Prevent multiple triggers

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasOpened) // If player touches it
        {
            door.OpenDoor(); // Open the door
            hasOpened = true; // Prevents multiple triggers
            // gameObject.SetActive(false); // Uncomment this if you WANT the box to disappear
        }
    }
}
