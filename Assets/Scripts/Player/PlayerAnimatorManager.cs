using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    [HideInInspector] internal Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Plays a specified animation and sets whether it will restrict interaction dependent animations from being played after it
    /// </summary>
    internal void PlayTargetAnimation(string targetAnim, bool isInteracting=true)
    {
        //Play a specific animation, if isInteracting is true, no other inputs can be performed during the animation
        animator.applyRootMotion = isInteracting;
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnim, 0.2f);
    }

    public void EnableIsInteracting()
    {
        animator.SetBool("isInteracting", true);
    }

    public void DisableIsInteracting()
    {
        animator.SetBool("isInteracting", false);
    }
}
