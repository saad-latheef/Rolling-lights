using UnityEngine;

public class PushableBox : MonoBehaviour
{
    public float pushForce = 5f; // Force applied to the box when pushed
    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure your ball has the tag "Player"
        {
            // Get the direction of the collision
            Vector2 direction = collision.contacts[0].point - (Vector2)transform.position;
            direction = -direction.normalized; // Reverse the direction to push the box

            // Move the box smoothly
            rb.MovePosition(rb.position + direction * pushForce * Time.deltaTime);
        }
    }
}