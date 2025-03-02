using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the soldier moves
    private Vector2 targetPosition;
    private bool isMoving = false;

    public void MoveToTarget(Vector2 target)
    {
        targetPosition = target;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the soldier towards the target position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving if the soldier reaches the target position
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
