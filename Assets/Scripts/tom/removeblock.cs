using UnityEngine;

public class RemoveTargetObject : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to remove
    public string interactionTag = "Player"; // Tag of the object that can trigger the removal (e.g., the ball)
    private bool hasTriggered = false; // Flag to track if the script has already been triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(interactionTag) && !hasTriggered) // Check if the interacting object has the correct tag and the script hasn't been triggered yet
        {
            hasTriggered = true; // Mark the script as triggered
            RemoveTarget();
        }
    }

    private void RemoveTarget()
    {
        if (targetObject != null)
        {
            Destroy(targetObject); // Remove the target object from the scene
            Debug.Log("Target object removed by: " + gameObject.name);
        }
        else
        {
            Debug.LogError("Target object reference is missing!");
        }
    }
}