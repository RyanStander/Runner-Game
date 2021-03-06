//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/PlayerController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""37307df6-8978-4812-958d-ee336eb0d55b"",
            ""actions"": [
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""a306ed16-ef06-46fa-b66f-db8d83e91284"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7019fa1a-4ef2-424d-a10a-630adb5e87f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""349fae40-6c5b-4425-9ea1-3d227570b081"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""5c94aa9c-aed4-4bf8-b65a-1f7d5002e762"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a18adb12-37d7-499a-a99c-1bb6d7be3506"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46b9fab4-b456-40ac-acc7-b873183aa3c0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca0f748b-da2a-455e-a014-9e7638ef86bb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07c896dd-e6e4-4610-ab8f-17eec98e2e90"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Slide = m_CharacterControls.FindAction("Slide", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_MoveLeft = m_CharacterControls.FindAction("MoveLeft", throwIfNotFound: true);
        m_CharacterControls_MoveRight = m_CharacterControls.FindAction("MoveRight", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Slide;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_MoveLeft;
    private readonly InputAction m_CharacterControls_MoveRight;
    public struct CharacterControlsActions
    {
        private @PlayerController m_Wrapper;
        public CharacterControlsActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Slide => m_Wrapper.m_CharacterControls_Slide;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @MoveLeft => m_Wrapper.m_CharacterControls_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_CharacterControls_MoveRight;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Slide.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSlide;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @MoveLeft.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoveRight;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnSlide(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
    }
}
