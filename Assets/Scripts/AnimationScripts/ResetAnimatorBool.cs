using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{

    [SerializeField,Tooltip("The bool that will be modified in the animator")] private string targetBool;
    [SerializeField, Tooltip("Whether the bool will be set to true or false")] private bool status;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(targetBool, status);
    }
}
