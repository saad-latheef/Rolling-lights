using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Ensures Rigidbody is attached
public class PushableBox3D : MonoBehaviour
{
    [Header("Boundaries")]
    public Transform rightBoundary;
    public Transform topBoundary;
    public Transform bottomBoundary;
    public Transform frontBoundary;
    public Transform backBoundary;
    public float pushForce = 10f; // Increased for better response

    [Header("Soldier Control")]
    public GameObject soldier;
    public Vector3 soldierTargetPosition;
    public float soldierMoveSpeed = 5f;
    public string triggerTag = "RemoveBox";

    private Rigidbody rb;
    private bool shouldMoveSoldier;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Critical for physics movement
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Better collision
    }

    void FixedUpdate() // Using FixedUpdate for physics
    {
        if (shouldMoveSoldier && soldier)
        {
            soldier.transform.position = Vector3.MoveTowards(
                soldier.transform.position,
                soldierTargetPosition,
                soldierMoveSpeed * Time.fixedDeltaTime
            );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate push direction from collision point
            Vector3 pushDir = (transform.position - collision.contacts[0].point).normalized;
            pushDir.y = 0; // Optional: Remove vertical push if needed
            
            // Apply force directly to Rigidbody
            rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            
            Debug.DrawRay(collision.contacts[0].point, pushDir * 5, Color.red, 2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Destroy(gameObject, 0.1f); // Small delay to avoid frame issues
            shouldMoveSoldier = true;
            Debug.Log("Box destroyed, soldier moving");
        }
    }
}