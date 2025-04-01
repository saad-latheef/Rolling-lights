using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Assign buttons in Inspector

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
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
        else
        {
            levelButtons[i].interactable = false;
        }
    }
}



 public void LoadLevel(int levelIndex)
{
    Debug.Log("Button Clicked! Trying to load Level: " + levelIndex);

    if (SceneManager.GetSceneByName("Level" + levelIndex) != null)
    {
        Debug.Log("Scene Exists: Loading Level " + levelIndex);
        SceneManager.LoadScene("Level" + levelIndex);
    }
    else
    {
        Debug.LogError("Scene Level" + levelIndex + " is NOT in Build Settings!");
    }
}


    
}
