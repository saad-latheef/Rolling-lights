using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the soldier moves
    private Vector3 targetPosition;
    private bool isMoving = false;

    public void MoveToTarget(Vector3 target)
    {
        targetPosition = target;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the soldier towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving if the soldier reaches the target position
            if ((Vector3)transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
