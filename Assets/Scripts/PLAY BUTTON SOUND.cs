using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonClickSound; // Assign an AudioSource in the Inspector

    public void PlaySound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }
}
