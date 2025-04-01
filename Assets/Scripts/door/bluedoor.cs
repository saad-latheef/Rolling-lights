using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject door;               // The door object to enable/disable
    public AudioSource doorOpenSound;     // AudioSource to play the door opening sound

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);  // Disable the door object

            // Play door opening sound if assigned
            if (doorOpenSound != null)
            {
                doorOpenSound.Play();
            }

            // Play the door animation (if assigned)
            GameObject.Find("Blue door").GetComponent<Animator>().SetBool("Door", true);
        }
        else
        {
            door.SetActive(true);  // If not the player, make the door visible
        }
    }
}
