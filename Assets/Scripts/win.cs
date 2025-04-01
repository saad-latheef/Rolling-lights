using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public AudioSource winSound; // Assign in Inspector
    public Animator transition; // Assign in Inspector
    public float transitionTime = 1f; // Adjust as needed
    private bool hasTriggered = false; // Prevents multiple triggers

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // Ensure it only triggers once
            StartCoroutine(HandleWin());
        }
    }

    IEnumerator HandleWin()
    {
        // Play win sound
        if (winSound != null)
            winSound.Play();

        // Get the currently unlocked level
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        // Get the current level number from its name
        int currentLevel;
        if (int.TryParse(SceneManager.GetActiveScene().name.Replace("Level", ""), out currentLevel))
        {
            Debug.Log("Winning Level: " + currentLevel);
        
            // Unlock the next level **only if it matches the current unlocked level**
            if (unlockedLevel == currentLevel)
            {
                PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
                PlayerPrefs.Save();
                Debug.Log("Newly Unlocked Level: " + (unlockedLevel + 1));
            }
        }
        else
        {
            Debug.LogError("Scene name format is incorrect. Make sure your scenes are named 'Level1', 'Level2', etc.");
        }

        // Play transition animation
        if (transition != null)
            transition.SetTrigger("Start");

        // Wait for animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load Level Selection screen
        SceneManager.LoadScene("LevelSelection");
    }
}
