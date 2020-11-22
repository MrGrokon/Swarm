// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""8ddcf039-1877-4b93-a651-fb27b952dfb9"",
            ""actions"": [
                {
                    ""name"": ""Move R/L"",
                    ""type"": ""Value"",
                    ""id"": ""2f8c2fc3-e5cc-470a-9078-6d7f886e9949"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move F/B"",
                    ""type"": ""Value"",
                    ""id"": ""ac529ef9-3ad7-4e11-909e-4c51b7b601b8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1ebf3f2-d7e2-4070-a3af-a7dacddb9b8c"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move R/L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8eae4600-a810-4a45-8354-c959909eaf89"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move F/B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_MoveRL = m_Actions.FindAction("Move R/L", throwIfNotFound: true);
        m_Actions_MoveFB = m_Actions.FindAction("Move F/B", throwIfNotFound: true);
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

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_MoveRL;
    private readonly InputAction m_Actions_MoveFB;
    public struct ActionsActions
    {
        private @PlayerInputs m_Wrapper;
        public ActionsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRL => m_Wrapper.m_Actions_MoveRL;
        public InputAction @MoveFB => m_Wrapper.m_Actions_MoveFB;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @MoveRL.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRL;
                @MoveRL.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRL;
                @MoveRL.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRL;
                @MoveFB.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveFB;
                @MoveFB.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveFB;
                @MoveFB.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveFB;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRL.started += instance.OnMoveRL;
                @MoveRL.performed += instance.OnMoveRL;
                @MoveRL.canceled += instance.OnMoveRL;
                @MoveFB.started += instance.OnMoveFB;
                @MoveFB.performed += instance.OnMoveFB;
                @MoveFB.canceled += instance.OnMoveFB;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IActionsActions
    {
        void OnMoveRL(InputAction.CallbackContext context);
        void OnMoveFB(InputAction.CallbackContext context);
    }
}
