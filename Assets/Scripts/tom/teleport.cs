using UnityEngine;

public class OneWayTeleporter : MonoBehaviour
{
    public Vector3 teleportPosition; // Custom position to teleport the player to
    public AudioClip teleportSound;  // Assign the teleportation sound in Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get or Add AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the tag "Player"
        {
            PlayTeleportSound();
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportPosition;
        Debug.Log("Player teleported to: " + teleportPosition);
    }

    private void PlayTeleportSound()
    {
        if (teleportSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(teleportSound); // Play sound effect
        }
    }
}
