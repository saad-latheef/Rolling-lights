using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject soldier; // Reference to the soldier GameObject
    public Vector3 targetPosition; // Target position for the soldier to move to
    public AudioClip buttonSound; // Sound to play when triggered

    private AudioSource audioSource;

    private void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure your ball has the tag "Player"
        {
            MoveSoldier();
            PlaySound();
        }
    }

    private void MoveSoldier()
    {
        SoldierController soldierController = soldier.GetComponent<SoldierController>();
        if (soldierController != null)
        {
            soldierController.MoveToTarget(targetPosition);
            Debug.Log("Soldier Moved");
        }
    }

    private void PlaySound()
    {
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound); // Play the sound
            Debug.Log("Sound Played: " + buttonSound.name);
        }
    }
}

