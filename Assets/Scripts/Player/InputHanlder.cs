using UnityEngine;
using UnityEngine.InputSystem;

public class InputHanlder : MonoBehaviour
{
    private PlayerController inputActions;

    //Movement Inputs
    [HideInInspector] internal bool slideInput, jumpInput, moveRight, moveLeft;

    private void Awake()
    {
        //check if an input actions has been assigned
        if (inputActions==null)
        {
            //if not input actions is set, create one
            inputActions = new PlayerController();

            //Assign vairables to input actions
            AssignInputs();
        }

        //Enable the input actions, allows for reading the inputs
        inputActions.Enable();
    }

    /// <summary>
    /// Resets the input variables so that do not queue up for animations
    /// </summary>
    internal void ResetInputs()
    {
        slideInput = false;
        jumpInput = false;
        moveRight = false;
        moveLeft = false;
    }

    /// <summary>
    /// Assigns all inputs of input actions to variables. Lets other scripts know whether inputs have been given
    /// </summary>
    private void AssignInputs()
    {
        #region Movement
        //Dodging
        //Slide
        inputActions.CharacterControls.Slide.performed += i => slideInput = true;
        //Jump
        inputActions.CharacterControls.Jump.performed += i => jumpInput = true;

        //Strafing
        //Right
        inputActions.CharacterControls.MoveRight.performed += i => moveRight = true;
        //Left
        inputActions.CharacterControls.MoveLeft.performed += i => moveLeft = true;
        #endregion
    }

    internal void EnablePlayerControls()
    {
        
    }

    internal void DisablePlayerControls()
    {

    }
}
