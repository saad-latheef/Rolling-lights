using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToLevelSelection : MonoBehaviour
{
    public Animator transition;  // Assign the transition Animator in Inspector
    public float transitionTime = 1f;  // Adjust as needed

    public void LoadLevelSelection()
    {
        StartCoroutine(LoadSelectionScene());
    }

    IEnumerator LoadSelectionScene()
    {
        // Play transition animation
        if (transition != null)
            transition.SetTrigger("Start");

        // Wait for transition to complete
        yield return new WaitForSeconds(transitionTime);

        // Load Level Selection Scene
        SceneManager.LoadScene("LevelSelection");
    }
}
