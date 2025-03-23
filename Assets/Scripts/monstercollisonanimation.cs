using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterFailHandler : MonoBehaviour
{
    [Header("Fail Screen Settings")]
    public GameObject failScreen; // The UI Panel for the fail screen
    public Animator failScreenAnimator; // Animator for the fail screen
    public AudioClip failSound; // Sound to play when the player fails
    public Button restartButton; // The restart button on the fail screen

    [Header("Monster Settings")]
    public float speed = 2f; // Speed of the monster's movement
    public float distance = 5f; // Distance the monster moves
    public bool moveOnXAxis = true; // Whether the monster moves on the X or Y axis

    private Vector3 startPosition; // Starting position of the monster
    private AudioSource audioSource; // AudioSource for playing sounds

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
        // Move the monster back and forth along the chosen axis
        if (moveOnXAxis)
        {
            float newX = startPosition.x + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else
        {
            float newY = startPosition.y + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
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