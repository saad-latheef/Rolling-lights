using UnityEngine;

public class PushableBox : MonoBehaviour
{
    public float pushForce = 5f; // Force applied to the box when pushed
    public Transform topBoundary; // Top boundary
    public Transform rightBoundary; // Right boundary
    public Transform bottomBoundary; // Bottom boundary
    public string colliderTag = "RemoveBox"; // Tag of the collider that removes the box

    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Check if boundaries are assigned
        if (topBoundary == null || rightBoundary == null || bottomBoundary == null)
        {
            Debug.LogError("Boundaries are not assigned!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure your ball has the tag "Player"
        {
            // Get the direction of the collision
            Vector2 direction = collision.contacts[0].point - (Vector2)transform.position;
            direction = -direction.normalized; // Reverse the direction to push the box

            // Calculate the new position
            Vector2 newPosition = rb.position + direction * pushForce * Time.deltaTime;

            // Clamp the new position within the boundaries
            newPosition.x = Mathf.Clamp(newPosition.x, -Mathf.Infinity, rightBoundary.position.x); // Constrain X to the right boundary
            newPosition.y = Mathf.Clamp(newPosition.y, bottomBoundary.position.y, topBoundary.position.y); // Constrain Y between bottom and top boundaries

            // Move the box
            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(colliderTag)) // Check if the collider has the specified tag
        {
            RemoveBox();
        }
    }

    private void RemoveBox()
    {
        // Remove the box from the scene
        Destroy(gameObject);
        Debug.Log("Box removed!");
    }
}