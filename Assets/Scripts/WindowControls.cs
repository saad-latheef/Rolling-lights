using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WindowControls : MonoBehaviour
{
    public RectTransform windowBar; // Assign in Inspector
    public float hideSpeed = 0.5f;  // Speed for showing/hiding

    private bool isVisible = false;

    // Windows API functions for window control
    [DllImport("user32.dll")] private static extern void ShowWindow(System.IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")] private static extern System.IntPtr GetActiveWindow();
    
    private const int SW_MINIMIZE = 6;
    private const int SW_MAXIMIZE = 3;
    private const int SW_RESTORE = 9;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep across scenes
    }

    void Update()
    {
        if (Input.mousePosition.y >= Screen.height - 10) 
        {
            if (!isVisible) ShowBar();
        }
        else 
        {
            if (isVisible) HideBar();
        }
    }

    void ShowBar()
    {
        isVisible = true;
        LeanTween.moveY(windowBar, 0, hideSpeed).setEase(LeanTweenType.easeOutQuad);
    }

    void HideBar()
    {
        isVisible = false;
        LeanTween.moveY(windowBar, -windowBar.rect.height, hideSpeed).setEase(LeanTweenType.easeInQuad);
    }

    public void MinimizeWindow()
    {
        ShowWindow(GetActiveWindow(), SW_MINIMIZE);
    }

    public void MaximizeWindow()
    {
        ShowWindow(GetActiveWindow(), SW_MAXIMIZE);
    }

    public void RestoreWindow()
    {
        ShowWindow(GetActiveWindow(), SW_RESTORE);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
