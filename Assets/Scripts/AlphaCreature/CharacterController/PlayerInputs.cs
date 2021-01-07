// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/AlphaCreature/CharacterController/PlayerInputs.inputactions'

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
                    ""name"": ""RotateCameraY"",
                    ""type"": ""Value"",
                    ""id"": ""30eb780b-7b1c-434f-9c28-d242e5f7c916"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCameraX"",
                    ""type"": ""Value"",
                    ""id"": ""31a3c659-2a3e-47bb-8825-25983401572a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GetPrey"",
                    ""type"": ""Button"",
                    ""id"": ""414cb75d-f653-4d94-bdd5-13ae7de80e17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CreateBeta"",
                    ""type"": ""Button"",
                    ""id"": ""41137e2c-55ea-4f0a-897a-310e94d80fb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FormationX"",
                    ""type"": ""Value"",
                    ""id"": ""1466461a-958d-44e8-86e7-a2050fe97594"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FormationY"",
                    ""type"": ""Value"",
                    ""id"": ""d51095f9-6607-40f8-9b9c-d1ce582879af"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftSprintButton"",
                    ""type"": ""Button"",
                    ""id"": ""4f322ce2-da05-49c4-bdc2-46ecfcf58a92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightSprintButton"",
                    ""type"": ""Button"",
                    ""id"": ""d72abd5e-8a56-4ae4-8207-5105cef0fea9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""c473b79d-657b-427a-ac0e-00df27d82814"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""04e7ddf9-d0f6-4378-85c9-64883ec6d166"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTarget"",
                    ""type"": ""Button"",
                    ""id"": ""56c67722-9b8b-4175-8c07-eb9009b34ce3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Button"",
                    ""id"": ""5e72a2dd-47ac-490f-895a-038ea3828592"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Targeting"",
                    ""type"": ""Button"",
                    ""id"": ""39aca463-fc6b-4b62-b347-2011029bb249"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTarget"",
                    ""type"": ""Button"",
                    ""id"": ""c4e5bc7b-6e62-415c-996c-6da3bb139e35"",
                    ""expectedControlType"": ""Button"",
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
                    ""id"": ""f0833c3a-0ae1-45d0-9e2a-0293aca22ec2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetPrey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17023f43-c126-48fa-9301-29dae1ae37d3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CreateBeta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85274c16-b37a-4478-b195-607259706fef"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FormationX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04326f6c-4cbf-4f12-86f4-2d448ae8de85"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FormationY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce823774-a4ef-4cd6-a580-a9f76a667b06"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSprintButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ece33bb3-17f2-4789-a3f2-0fee0839b4bc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc051d73-4231-41b4-b6d6-e50f92b8c6bc"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30c90430-ce0a-40eb-bc66-933571017a1d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSprintButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19fda5a7-9271-4891-a1bb-75ec585a4f7c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""308ffd7d-04aa-4530-859b-46950d03ab63"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b146c8e8-5ec7-48a3-af6f-88f863815362"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e769711-77b3-4789-8748-b3983b0b2286"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Targeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6bd43141-14d1-48c8-8a40-6500b5ae0cbe"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTarget"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""21fedbcb-e8aa-495f-b262-a44b29b54842"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7cee88f8-c028-48b4-a504-d37b7a2964b3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        m_Actions_RotateCameraY = m_Actions.FindAction("RotateCameraY", throwIfNotFound: true);
        m_Actions_RotateCameraX = m_Actions.FindAction("RotateCameraX", throwIfNotFound: true);
        m_Actions_GetPrey = m_Actions.FindAction("GetPrey", throwIfNotFound: true);
        m_Actions_CreateBeta = m_Actions.FindAction("CreateBeta", throwIfNotFound: true);
        m_Actions_FormationX = m_Actions.FindAction("FormationX", throwIfNotFound: true);
        m_Actions_FormationY = m_Actions.FindAction("FormationY", throwIfNotFound: true);
        m_Actions_LeftSprintButton = m_Actions.FindAction("LeftSprintButton", throwIfNotFound: true);
        m_Actions_RightSprintButton = m_Actions.FindAction("RightSprintButton", throwIfNotFound: true);
        m_Actions_Attack = m_Actions.FindAction("Attack", throwIfNotFound: true);
        m_Actions_Reset = m_Actions.FindAction("Reset", throwIfNotFound: true);
        m_Actions_SwitchTarget = m_Actions.FindAction("SwitchTarget", throwIfNotFound: true);
        m_Actions_Climb = m_Actions.FindAction("Climb", throwIfNotFound: true);
        m_Actions_Targeting = m_Actions.FindAction("Targeting", throwIfNotFound: true);
        m_Actions_SwitchTarget = m_Actions.FindAction("SwitchTarget", throwIfNotFound: true);
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
    private readonly InputAction m_Actions_RotateCameraY;
    private readonly InputAction m_Actions_RotateCameraX;
    private readonly InputAction m_Actions_GetPrey;
    private readonly InputAction m_Actions_CreateBeta;
    private readonly InputAction m_Actions_FormationX;
    private readonly InputAction m_Actions_FormationY;
    private readonly InputAction m_Actions_LeftSprintButton;
    private readonly InputAction m_Actions_RightSprintButton;
    private readonly InputAction m_Actions_Attack;
    private readonly InputAction m_Actions_Reset;
    private readonly InputAction m_Actions_SwitchTarget;
    private readonly InputAction m_Actions_Climb;
    private readonly InputAction m_Actions_Targeting;
    public struct ActionsActions
    {
        private @PlayerInputs m_Wrapper;
        public ActionsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRL => m_Wrapper.m_Actions_MoveRL;
        public InputAction @MoveFB => m_Wrapper.m_Actions_MoveFB;
        public InputAction @RotateCameraY => m_Wrapper.m_Actions_RotateCameraY;
        public InputAction @RotateCameraX => m_Wrapper.m_Actions_RotateCameraX;
        public InputAction @GetPrey => m_Wrapper.m_Actions_GetPrey;
        public InputAction @CreateBeta => m_Wrapper.m_Actions_CreateBeta;
        public InputAction @FormationX => m_Wrapper.m_Actions_FormationX;
        public InputAction @FormationY => m_Wrapper.m_Actions_FormationY;
        public InputAction @LeftSprintButton => m_Wrapper.m_Actions_LeftSprintButton;
        public InputAction @RightSprintButton => m_Wrapper.m_Actions_RightSprintButton;
        public InputAction @Attack => m_Wrapper.m_Actions_Attack;
        public InputAction @Reset => m_Wrapper.m_Actions_Reset;
        public InputAction @SwitchTarget => m_Wrapper.m_Actions_SwitchTarget;
        public InputAction @Climb => m_Wrapper.m_Actions_Climb;
        public InputAction @Targeting => m_Wrapper.m_Actions_Targeting;
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
                @RotateCameraY.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraY;
                @RotateCameraY.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraY;
                @RotateCameraY.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraY;
                @RotateCameraX.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraX;
                @RotateCameraX.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraX;
                @RotateCameraX.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotateCameraX;
                @GetPrey.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnGetPrey;
                @GetPrey.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnGetPrey;
                @GetPrey.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnGetPrey;
                @CreateBeta.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCreateBeta;
                @CreateBeta.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCreateBeta;
                @CreateBeta.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCreateBeta;
                @FormationX.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationX;
                @FormationX.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationX;
                @FormationX.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationX;
                @FormationY.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationY;
                @FormationY.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationY;
                @FormationY.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnFormationY;
                @LeftSprintButton.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftSprintButton;
                @LeftSprintButton.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftSprintButton;
                @LeftSprintButton.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftSprintButton;
                @RightSprintButton.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightSprintButton;
                @RightSprintButton.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightSprintButton;
                @RightSprintButton.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightSprintButton;
                @Attack.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @Reset.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @SwitchTarget.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
                @SwitchTarget.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
                @SwitchTarget.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
                @Climb.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClimb;
                @Climb.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClimb;
                @Climb.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClimb;
                @Targeting.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTargeting;
                @Targeting.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTargeting;
                @Targeting.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTargeting;
                @SwitchTarget.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
                @SwitchTarget.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
                @SwitchTarget.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchTarget;
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
                @RotateCameraY.started += instance.OnRotateCameraY;
                @RotateCameraY.performed += instance.OnRotateCameraY;
                @RotateCameraY.canceled += instance.OnRotateCameraY;
                @RotateCameraX.started += instance.OnRotateCameraX;
                @RotateCameraX.performed += instance.OnRotateCameraX;
                @RotateCameraX.canceled += instance.OnRotateCameraX;
                @GetPrey.started += instance.OnGetPrey;
                @GetPrey.performed += instance.OnGetPrey;
                @GetPrey.canceled += instance.OnGetPrey;
                @CreateBeta.started += instance.OnCreateBeta;
                @CreateBeta.performed += instance.OnCreateBeta;
                @CreateBeta.canceled += instance.OnCreateBeta;
                @FormationX.started += instance.OnFormationX;
                @FormationX.performed += instance.OnFormationX;
                @FormationX.canceled += instance.OnFormationX;
                @FormationY.started += instance.OnFormationY;
                @FormationY.performed += instance.OnFormationY;
                @FormationY.canceled += instance.OnFormationY;
                @LeftSprintButton.started += instance.OnLeftSprintButton;
                @LeftSprintButton.performed += instance.OnLeftSprintButton;
                @LeftSprintButton.canceled += instance.OnLeftSprintButton;
                @RightSprintButton.started += instance.OnRightSprintButton;
                @RightSprintButton.performed += instance.OnRightSprintButton;
                @RightSprintButton.canceled += instance.OnRightSprintButton;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @SwitchTarget.started += instance.OnSwitchTarget;
                @SwitchTarget.performed += instance.OnSwitchTarget;
                @SwitchTarget.canceled += instance.OnSwitchTarget;
                @Climb.started += instance.OnClimb;
                @Climb.performed += instance.OnClimb;
                @Climb.canceled += instance.OnClimb;
                @Targeting.started += instance.OnTargeting;
                @Targeting.performed += instance.OnTargeting;
                @Targeting.canceled += instance.OnTargeting;
                @SwitchTarget.started += instance.OnSwitchTarget;
                @SwitchTarget.performed += instance.OnSwitchTarget;
                @SwitchTarget.canceled += instance.OnSwitchTarget;
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
        void OnRotateCameraY(InputAction.CallbackContext context);
        void OnRotateCameraX(InputAction.CallbackContext context);
        void OnGetPrey(InputAction.CallbackContext context);
        void OnCreateBeta(InputAction.CallbackContext context);
        void OnFormationX(InputAction.CallbackContext context);
        void OnFormationY(InputAction.CallbackContext context);
        void OnLeftSprintButton(InputAction.CallbackContext context);
        void OnRightSprintButton(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnSwitchTarget(InputAction.CallbackContext context);
        void OnClimb(InputAction.CallbackContext context);
        void OnTargeting(InputAction.CallbackContext context);
    }
}
