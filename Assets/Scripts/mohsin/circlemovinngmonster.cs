using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterFailHandlerr : MonoBehaviour
{
    [Header("Fail Screen Settings")]
    public GameObject failScreen; // The UI Panel for the fail screen
    public Animator failScreenAnimator; // Animator for the fail screen
    public AudioClip failSound; // Sound to play when the player fails
    public Button restartButton; // The restart button on the fail screen

    [Header("Monster Settings")]
    public float speed = 2f; // Speed of the monster's movement
    public float radius = 2f; // Radius of circular movement

    private Vector3 startPosition; // Starting position of the monster
    private AudioSource audioSource; // AudioSource for playing sounds
    private float angle = 0f; // Angle for circular movement

    void Start()
    {
        // Initialize the monster's starting position
        startPosition = transform.position;

        // Ensure the fail screen is hidden at the start
        if (failScreen != null)
        {
            failScreen.SetActive(false);
        }

        // Set up the restart button
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartLevel);
        }

        // Set up the AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Move the monster in a circular path
        angle += speed * Time.deltaTime;
        float newX = startPosition.x + Mathf.Cos(angle) * radius;
        float newY = startPosition.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the monster
        if (collision.CompareTag("Player"))
        {
            // Play the fail sound
            if (failSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(failSound);
            }

            // Show the fail screen
            ShowFailScreen();

            // Pause the game
            PauseGame();
        }
    }

    private void ShowFailScreen()
    {
        if (failScreen != null)
        {
            // Enable the fail screen
            failScreen.SetActive(true);

            // Trigger the animation
            if (failScreenAnimator != null)
            {
                failScreenAnimator.updateMode = AnimatorUpdateMode.UnscaledTime; // Make animation independent of time scale
                failScreenAnimator.SetTrigger("Show");
            }
            else
            {
                Debug.LogError("FailScreenAnimator is not assigned!");
            }
        }
        else
        {
            Debug.LogError("FailScreen is not assigned!");
        }
    }

    private void PauseGame()
    {
        // Pause the game by setting time scale to 0
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        // Resume the game by setting time scale to 1
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        // Resume the game before restarting
        ResumeGame();

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
