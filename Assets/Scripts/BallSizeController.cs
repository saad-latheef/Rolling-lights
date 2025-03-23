using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    private Vector3 originalSize;
    public Vector3 smallSize = new Vector3(0.5f, 0.5f, 1f); // Adjust as needed
    public AudioClip smallBoxSound; // Sound when ball shrinks
    public AudioClip bigBoxSound;   // Sound when ball restores

    private AudioSource audioSource;

    void Start()
    {
        originalSize = transform.localScale; // Store the original size
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // Check what the ball is touching

        if (other.CompareTag("Smallbox"))
        {
            transform.localScale = smallSize;
            PlaySound(smallBoxSound);
            Debug.Log("Ball Shrunk! New Size: " + transform.localScale);
        }
        else if (other.CompareTag("Bigbox"))
        {
            transform.localScale = originalSize;
            PlaySound(bigBoxSound);
            Debug.Log("Ball Restored! New Size: " + transform.localScale);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null) 
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
