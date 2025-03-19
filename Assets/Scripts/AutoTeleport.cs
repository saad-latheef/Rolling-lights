using UnityEngine;
using System.Collections;

public class AutoTeleport : MonoBehaviour
{
    public Transform teleportTarget; // Target position
    public bool autoTeleportEnabled = false; // Enable/Disable auto teleport
    public float teleportInterval = 3f; // Auto teleport delay
    public float fadeDuration = 0.5f; // Duration of fade effect
    public AudioClip teleportSound; // Teleportation sound effect
    public GameObject teleportEffect; // Optional teleport particle effect

    private bool playerInside = false; // Tracks if player is inside trigger zone
    private Transform playerTransform;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            playerInside = true;
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void Update()
    {
        if (autoTeleportEnabled && playerInside)
        {
            StartCoroutine(PerformAutoTeleport());
        }
    }

    IEnumerator PerformAutoTeleport()
    {
        yield return new WaitForSeconds(teleportInterval);
        if (playerInside)
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator TeleportPlayer()
    {
        if (playerTransform == null) yield break;

        SpriteRenderer playerSprite = playerTransform.GetComponent<SpriteRenderer>();

        // Fade out before teleporting
        if (playerSprite != null)
        {
            yield return StartCoroutine(FadeSprite(playerSprite, 1f, 0f, fadeDuration));
        }

        // Play teleport sound
        if (teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }

        // Spawn teleport effect at current position
        if (teleportEffect != null)
        {
            Instantiate(teleportEffect, playerTransform.position, Quaternion.identity);
        }

        // Teleport the player forward
        playerTransform.position = teleportTarget.position;

        // Spawn teleport effect at new position
        if (teleportEffect != null)
        {
            Instantiate(teleportEffect, playerTransform.position, Quaternion.identity);
        }

        // Fade in after teleporting
        if (playerSprite != null)
        {
            yield return StartCoroutine(FadeSprite(playerSprite, 0f, 1f, fadeDuration));
        }
    }

    IEnumerator FadeSprite(SpriteRenderer sprite, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = sprite.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            sprite.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        sprite.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
