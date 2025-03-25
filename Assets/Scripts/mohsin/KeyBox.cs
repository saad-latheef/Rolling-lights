using UnityEngine;

public class KeyBox : MonoBehaviour
{
    public DoorController door; // Assign the door in the Inspector
    public AudioClip keyBoxSound; // Sound when the key box is touched

    private bool hasOpened = false; // Prevent multiple triggers
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasOpened) // If player touches it
        {
            door.OpenDoor(); // Open the door
            PlaySound();
            hasOpened = true; // Prevents multiple triggers
            
            // gameObject.SetActive(false); // Uncomment this if you WANT the box to disappear
        }
    }

    void PlaySound()
    {
        if (keyBoxSound != null)
        {
            audioSource.PlayOneShot(keyBoxSound);
        }
    }
}
