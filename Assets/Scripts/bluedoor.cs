using UnityEngine;


public class ButtonBehavior : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
            GameObject.Find("Blue door").GetComponent<Animator>().SetBool("Door", true);
        }
        else
        {
            door.SetActive(true);
        }
    }

}