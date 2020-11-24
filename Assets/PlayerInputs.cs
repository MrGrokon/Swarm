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
                },
                {
                    ""name"": ""Bridge R/L"",
                    ""type"": ""Value"",
                    ""id"": ""57bc3603-7e8e-4bca-bd26-5f930e58a9fe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bridge F/B"",
                    ""type"": ""Value"",
                    ""id"": ""92737d9d-605a-4bc8-ab84-84cdf834ba80"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""8dbfd0dc-38ce-49f3-b9ad-64b921f6af14"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bridge R/L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1911c0d5-9ce5-4416-b362-016d18b49a18"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bridge F/B"",
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
        m_Actions_BridgeRL = m_Actions.FindAction("Bridge R/L", throwIfNotFound: true);
        m_Actions_BridgeFB = m_Actions.FindAction("Bridge F/B", throwIfNotFound: true);
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
    private readonly InputAction m_Actions_BridgeRL;
    private readonly InputAction m_Actions_BridgeFB;
    public struct ActionsActions
    {
        private @PlayerInputs m_Wrapper;
        public ActionsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRL => m_Wrapper.m_Actions_MoveRL;
        public InputAction @MoveFB => m_Wrapper.m_Actions_MoveFB;
        public InputAction @BridgeRL => m_Wrapper.m_Actions_BridgeRL;
        public InputAction @BridgeFB => m_Wrapper.m_Actions_BridgeFB;
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
                @BridgeRL.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeRL;
                @BridgeRL.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeRL;
                @BridgeRL.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeRL;
                @BridgeFB.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeFB;
                @BridgeFB.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeFB;
                @BridgeFB.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnBridgeFB;
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
                @BridgeRL.started += instance.OnBridgeRL;
                @BridgeRL.performed += instance.OnBridgeRL;
                @BridgeRL.canceled += instance.OnBridgeRL;
                @BridgeFB.started += instance.OnBridgeFB;
                @BridgeFB.performed += instance.OnBridgeFB;
                @BridgeFB.canceled += instance.OnBridgeFB;
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
        void OnBridgeRL(InputAction.CallbackContext context);
        void OnBridgeFB(InputAction.CallbackContext context);
    }
}
