using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private Collider2D doorCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>(); // Get the door's collider
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor"); // Play open animation
        Destroy(doorCollider); // Remove the collider so the player can pass
    }
}
