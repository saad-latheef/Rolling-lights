using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public LevelManager levelManager; // Assign in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.UnlockNextLevel(); // Unlock the next level
            SceneManager.LoadScene("LevelSelection"); // Go to the level selection screen
        }
    }
}
