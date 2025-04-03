using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices; // Required for Windows API functions

public class TopPanelManager : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Assign in Inspector
    public Button closeButton, minimizeButton, resizeButton; // Assign in Inspector
    private bool isPanelVisible = false;
    private Coroutine hideCoroutine;

    [DllImport("user32.dll")]
    private static extern void ShowWindow(System.IntPtr hWnd, int nCmdShow);
    
    [DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();

    private const int SW_MINIMIZE = 6;
    private const int SW_MAXIMIZE = 3;
    private const int SW_RESTORE = 9;

    void Start()
    {
        // Ensure buttons work
        closeButton.onClick.AddListener(CloseGame);
        minimizeButton.onClick.AddListener(MinimizeGame);
        resizeButton.onClick.AddListener(ResizeGame);

        // Start with the panel hidden
        HidePanelInstantly();
    }

    void Update()
    {
        // Check if mouse is at the top of the screen
        if (Input.mousePosition.y >= Screen.height - 10 && !isPanelVisible)
        {
            ShowPanel();
        }
    }

    void ShowPanel()
    {
        isPanelVisible = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // Start the coroutine to auto-hide the panel
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(AutoHidePanel());
    }

    IEnumerator AutoHidePanel()
    {
        yield return new WaitForSeconds(3f); // Panel stays for 3 sec
        HidePanel();
    }

    void HidePanel()
    {
        isPanelVisible = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void HidePanelInstantly()
    {
        isPanelVisible = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void CloseGame()
    {
        Debug.Log("Closing Game...");
        Application.Quit();
    }

    void MinimizeGame()
    {
        Debug.Log("Minimizing Game...");
        ShowWindow(GetActiveWindow(), SW_MINIMIZE);
    }

    void ResizeGame()
    {
        Debug.Log("Resizing Game...");
        ShowWindow(GetActiveWindow(), SW_MAXIMIZE);
    }
}
