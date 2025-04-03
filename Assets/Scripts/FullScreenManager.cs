using UnityEngine;

public class FullScreenManager : MonoBehaviour
{
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow; // Forces fullscreen
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }
}
