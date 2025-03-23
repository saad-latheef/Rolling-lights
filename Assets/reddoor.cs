using UnityEngine;


public class RedDoor : MonoBehaviour
{

    public GameObject rdoor;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Red door").GetComponent<Animator>().SetBool("rdoor", true);

            rdoor.SetActive(false);
        }
        else
        {

            rdoor.SetActive(true);
        }
    }

}