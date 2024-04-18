using UnityEngine;

public class stopLoop : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("animation", 0, 0); // Replace "YourAnimationClipName" with the actual clip name
        }
        else
        {
            Debug.LogWarning("Animator component not found on the GameObject.");
        }
    }

    // This method will be called by the Animation Event
    public void StopPlayback()
    {
        if (animator != null)
        {
            animator.speed = 0f; // Set the animation speed to 0 to stop playback
        }
        else
        {
            Debug.LogWarning("Animator component not found on the GameObject.");
        }
    }
}