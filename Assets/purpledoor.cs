using UnityEngine;


public class PurpleDoor : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(true);
            GameObject.Find("Blue door").GetComponent<Animator>().SetBool("Door", false);
        }
        else
        {
            door.SetActive(false);
        }
    }

}