using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToLevelSelection : MonoBehaviour
{
    public Animator transition;  // Assign in Inspector
    public float transitionTime = 1f;  // Adjust as needed
    public AudioSource clickSound; // Assign in Inspector

    public void LoadLevelSelection()
    {
        StartCoroutine(LoadSelectionScene());
    }

    IEnumerator LoadSelectionScene()
    {
        // Play button click sound
        if (clickSound != null)
            clickSound.Play();

        // Play transition animation
        if (transition != null)
            transition.SetTrigger("Start");

        // Wait for transition & sound to finish
        yield return new WaitForSeconds(transitionTime);

        // Load Level Selection Scene
        SceneManager.LoadScene("LevelSelection");
    }
}
