using UnityEngine;

public class OneWayTeleporter : MonoBehaviour
{
    public Vector3 teleportPosition; // Custom position to teleport the player to

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the tag "Player"
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Teleport the player to the custom position
        player.transform.position = teleportPosition;
        Debug.Log("Player teleported to: " + teleportPosition);
    }
}