using UnityEngine;
using System.Runtime.InteropServices; // Required for Windows API

public class WindowControls : MonoBehaviour
{
    // Import Windows API functions
    [DllImport("user32.dll")] private static extern int ShowWindow(System.IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")] private static extern System.IntPtr GetActiveWindow();

    private const int SW_MINIMIZE = 6;
    private const int SW_MAXIMIZE = 3;
    private const int SW_RESTORE = 9;

    private bool isFullscreen = false;

    // Function to close the game
    public void CloseGame()
    {
        Application.Quit();
    }

    // Function to minimize the game window
    public void MinimizeGame()
    {
        ShowWindow(GetActiveWindow(), SW_MINIMIZE);
    }

    // Function to toggle fullscreen mode
    public void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;

        if (isFullscreen)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
            Screen.SetResolution(1280, 720, false); // Set window size when exiting fullscreen
        }
    }
}
