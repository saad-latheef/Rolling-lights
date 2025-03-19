using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    private Vector3 originalSize;
    public Vector3 smallSize = new Vector3(0.5f, 0.5f, 1f); // Adjust as needed

    void Start()
    {
        originalSize = transform.localScale; // Store the original size
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // Check what the ball is touching

        if (other.CompareTag("Smallbox"))
        {
            transform.localScale = smallSize;
            Debug.Log("Ball Shrunk! New Size: " + transform.localScale);
        }
        else if (other.CompareTag("Bigbox"))
        {
            transform.localScale = originalSize;
            Debug.Log("Ball Restored! New Size: " + transform.localScale);
        }
    }
}
