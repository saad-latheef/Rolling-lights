using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadePanel; // Assign the FadePanel Canvas Group in Inspector
    public float fadeDuration = 1.5f; // Adjust for smoothness

    void Start()
    {
        fadePanel.alpha = 0; // Ensure it starts invisible
    }

    public void RestartWithFade()
    {
        StartCoroutine(FadeOutAndRestart());
    }

    IEnumerator FadeOutAndRestart()
{
    float time = 0;

    while (time < fadeDuration)
    {
        fadePanel.alpha = Mathf.Lerp(0, 1, time / fadeDuration);
        time += Time.deltaTime;
        yield return null;
    }

    fadePanel.alpha = 1; // Ensure it’s fully black

    yield return new WaitForSeconds(1f); // ✅ Add this delay before restarting

    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}
