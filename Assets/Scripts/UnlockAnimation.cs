using UnityEngine;

public class UnlockAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("UnlockedLevels") > 1) // If a new level is unlocked
        {
            animator.SetTrigger("Unlock");
        }
    }
}
