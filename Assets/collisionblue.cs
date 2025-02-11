using UnityEngine;

using UnityEngine.Rendering.Universal; // For Light2D

public class ChangeOrbImageAndAnimator : MonoBehaviour
{
    public Sprite newOrbSprite; // The new sprite to change to when triggered
    public RuntimeAnimatorController newAnimatorController; // The new Animator Controller to switch to
    public Color newLightColor;

    private SpriteRenderer orbRenderer; // Reference to the orb's SpriteRenderer
    private Animator orbAnimator; // Reference to the orb's Animator
    private Light2D orbLight; // Reference to the orb's Light2D component

    void Start()
    {
        // Get the SpriteRenderer and Animator components attached to the orb
        orbRenderer = GetComponent<SpriteRenderer>();
        orbAnimator = GetComponent<Animator>();
        orbLight = GetComponent<Light2D>();


        // Check if the components exist
        if (orbRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the orb!");
        }
        if (orbAnimator == null)
        {
            Debug.LogError("Animator component not found on the orb!");
        }
        if (orbLight == null)
        {
            Debug.LogError("Light2D component not found on the orb!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the orb collided with a specific trigger
        if (other.CompareTag("bluechanger")) // Replace "ColorChanger" with your trigger's tag
        {
            // Change the orb's sprite to the new one
            if (newOrbSprite != null)
            {
                orbRenderer.sprite = newOrbSprite;
                Debug.Log("Orb sprite changed!");
            }
            else
            {
                Debug.LogWarning("New orb sprite is not assigned!");
            }

            // Change the orb's Animator Controller to the new one
            if (newAnimatorController != null)
            {
                orbAnimator.runtimeAnimatorController = newAnimatorController;
                Debug.Log("Orb Animator Controller changed!");
            }
            else
            {
                Debug.LogWarning("New Animator Controller is not assigned!");
            }
            if (orbLight != null)
            {
                orbLight.color = newLightColor;
                Debug.Log("Orb Light2D color changed!");
            }
            else
            {
                Debug.LogWarning("Light2D component is missing!");
            }
        }
    }
}