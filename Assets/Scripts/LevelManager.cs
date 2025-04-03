using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Assign buttons in Inspector
    public AudioSource buttonClickSound; // Assign in Inspector

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true;
                int levelIndex = i + 1; 

                levelButtons[i].onClick.RemoveAllListeners(); // Clear old events
                levelButtons[i].onClick.AddListener(() => StartCoroutine(PlaySoundAndLoad(levelIndex)));
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    IEnumerator PlaySoundAndLoad(int levelIndex)
    {
        if (buttonClickSound != null)
            buttonClickSound.Play(); // Play sound before loading

        yield return new WaitForSeconds(buttonClickSound.clip.length); // Wait for the sound to finish

        SceneManager.LoadScene("Level" + levelIndex);
    }
}
