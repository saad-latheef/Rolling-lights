using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Assign level buttons in the Inspector
    private int unlockedLevels;

    void Start()
    {
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1); // Default to level 1 unlocked

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < unlockedLevels)
                levelButtons[i].interactable = true; // Unlock
            else
                levelButtons[i].interactable = false; // Keep locked
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void UnlockNextLevel()
    {
        if (unlockedLevels < levelButtons.Length)
        {
            unlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);
            PlayerPrefs.Save();
        }
    }
}
