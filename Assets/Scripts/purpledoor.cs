using UnityEngine;


public class PurpleDoor : MonoBehaviour
{

    public GameObject pdoor;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameObject.Find("Purple door").GetComponent<Animator>().SetBool("pdoor", true);
            pdoor.SetActive(false);
        }
        else
        {

            pdoor.SetActive(true);
        }
    }

}