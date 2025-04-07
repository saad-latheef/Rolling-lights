using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonClickSound; // Assign in Inspector

    public void PlayGame()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play(); // Play the button sound
        }

        // Load the scene after a short delay to allow the sound to play
        Invoke("LoadLevelSelection", 0.3f);
    }

    private void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection"); // Load the level selection screen
    }
void Start()
{
    if (!PlayerPrefs.HasKey("GameInitialized")) // Only reset for fresh installs
    {
        PlayerPrefs.DeleteAll(); // Clears all stored PlayerPrefs
        PlayerPrefs.SetInt("UnlockedLevel", 1); // Ensures only Level 1 is unlocked
        PlayerPrefs.SetInt("GameInitialized", 1); // Mark as initialized
        PlayerPrefs.Save();
    }
}




}

