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
}
