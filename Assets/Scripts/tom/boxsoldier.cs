using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform targetPosition; // Where the soldier should move to
    private bool shouldMove = false;

    public void StartMoving()
    {
        shouldMove = true; // Trigger movement
    }

    private void Update()
    {
        if (shouldMove)
        {
            // Move towards target position
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
}