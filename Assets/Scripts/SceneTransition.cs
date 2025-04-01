using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MySceneTransition : MonoBehaviour  // Unique name!

{
    public Animator fadeAnimator;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
