using UnityEngine;

public class Bluedoorkey : MonoBehaviour
{
    public GameObject door;
    public AudioSource dooropensound; // Reference to the AudioSource component

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Play the sound when the player touches the button
            if (dooropensound != null)
            {
                dooropensound.Play();
            }

            // Disable the door and play the door opening animation
            door.SetActive(false);
            GameObject.Find("Blue door").GetComponent<Animator>().SetBool("Door", true);
        }
        else
        {
            door.SetActive(true);
        }
    }
}
