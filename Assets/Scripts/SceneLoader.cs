using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        GameObject panel = GameObject.Find("TopPanel"); // Find the panel in the scene
        if (panel != null)
        {
            panel.SetActive(true); // Ensure it's active
        }
    }
}
