// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""8e278639-aeae-4b86-91a3-f84a046a612d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""567f8c8d-20ab-49c5-80a9-87daf8b74d5b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""be29e7dd-9bc5-47cd-b8ab-14cf98194ff5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ea15a8d0-14e1-4c15-b42d-fa4dc99beef7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""7b80a0fd-87e3-449d-8df5-ad4060c76ce6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""42043d95-701b-4f62-8149-5b6b7373b9ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""405ddd2c-1c1c-4e33-a370-5701b8bbcf6e"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0c4947d-a216-4f5d-b1e2-d338038b9e19"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e7c52811-9000-4a9b-b081-70a393404c8d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""97f3e5c6-84cd-4fb7-abc7-453d9f0828d0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""552a99dc-f22c-484d-b59c-6c872159ffe1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6ada7e06-5fb4-442d-86b1-4f10058cd593"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f6088e-c6c1-451f-b9a3-d989e617a90f"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""845a58f2-d79b-4369-8ef4-d542e05a7488"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc8b273-9d11-4c88-8670-90500322685a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""c1b88483-5889-4c6e-b369-3d6455cc3f73"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""635d3e13-22b3-4b57-a98c-dabdfc975875"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9bc89c96-ff98-48aa-b0ad-cc2cce2019a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Defence"",
                    ""type"": ""Button"",
                    ""id"": ""15b152f6-cce3-4955-be4a-a892dd236caa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""11c9d39f-96a8-44bc-b1d8-ef563f64eec4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RemoveWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""1d7b2b34-9ba8-416f-a99d-4843a92cf3f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb2268c5-a944-416a-ae4d-afb650482a05"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""112747c2-147e-48fe-bd0b-3e04dab66290"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd6125d9-5ed3-43d8-9123-2be32d4080f1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58024ce2-f964-4933-af16-2d35bdbc2853"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a989833-6fe4-4fb0-82f4-5a222a30a965"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""acacffa1-f20a-4801-a9d8-7021399c3c08"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""4395bcfc-7338-4bce-9fad-b0b86f4d32c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""b264d9e7-6c6d-4191-986b-341fe28a1114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""58cac789-a18b-497f-bf6f-a51d36edd601"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40f69b5f-a011-4466-89b7-847279519bd6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b70d5cb6-e2a1-46d3-b60a-8d9fd51801f0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2960d18b-e7ad-48bb-b7a5-c84c497861f8"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""a6991f76-1f01-4cf8-97c4-936511ed782c"",
            ""actions"": [
                {
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""e3c3656e-8584-4d80-939a-4503b2561b11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4831d390-d987-4d9d-87e8-dc2b503016d1"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_RotateCamera = m_PlayerMovement.FindAction("RotateCamera", throwIfNotFound: true);
        m_PlayerMovement_Zoom = m_PlayerMovement.FindAction("Zoom", throwIfNotFound: true);
        m_PlayerMovement_Walk = m_PlayerMovement.FindAction("Walk", throwIfNotFound: true);
        m_PlayerMovement_Sprint = m_PlayerMovement.FindAction("Sprint", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Attack = m_PlayerActions.FindAction("Attack", throwIfNotFound: true);
        m_PlayerActions_Defence = m_PlayerActions.FindAction("Defence", throwIfNotFound: true);
        m_PlayerActions_Interact = m_PlayerActions.FindAction("Interact", throwIfNotFound: true);
        m_PlayerActions_RemoveWeapon = m_PlayerActions.FindAction("RemoveWeapon", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Inventory = m_UI.FindAction("Inventory", throwIfNotFound: true);
        m_UI_UseItem = m_UI.FindAction("UseItem", throwIfNotFound: true);
        m_UI_DropItem = m_UI.FindAction("DropItem", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Test = m_Debug.FindAction("Test", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_RotateCamera;
    private readonly InputAction m_PlayerMovement_Zoom;
    private readonly InputAction m_PlayerMovement_Walk;
    private readonly InputAction m_PlayerMovement_Sprint;
    public struct PlayerMovementActions
    {
        private @InputActions m_Wrapper;
        public PlayerMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @RotateCamera => m_Wrapper.m_PlayerMovement_RotateCamera;
        public InputAction @Zoom => m_Wrapper.m_PlayerMovement_Zoom;
        public InputAction @Walk => m_Wrapper.m_PlayerMovement_Walk;
        public InputAction @Sprint => m_Wrapper.m_PlayerMovement_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @RotateCamera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRotateCamera;
                @Zoom.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnZoom;
                @Walk.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnWalk;
                @Sprint.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Attack;
    private readonly InputAction m_PlayerActions_Defence;
    private readonly InputAction m_PlayerActions_Interact;
    private readonly InputAction m_PlayerActions_RemoveWeapon;
    public struct PlayerActionsActions
    {
        private @InputActions m_Wrapper;
        public PlayerActionsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerActions_Attack;
        public InputAction @Defence => m_Wrapper.m_PlayerActions_Defence;
        public InputAction @Interact => m_Wrapper.m_PlayerActions_Interact;
        public InputAction @RemoveWeapon => m_Wrapper.m_PlayerActions_RemoveWeapon;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                @Defence.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDefence;
                @Defence.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDefence;
                @Defence.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDefence;
                @Interact.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @RemoveWeapon.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRemoveWeapon;
                @RemoveWeapon.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRemoveWeapon;
                @RemoveWeapon.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRemoveWeapon;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Defence.started += instance.OnDefence;
                @Defence.performed += instance.OnDefence;
                @Defence.canceled += instance.OnDefence;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @RemoveWeapon.started += instance.OnRemoveWeapon;
                @RemoveWeapon.performed += instance.OnRemoveWeapon;
                @RemoveWeapon.canceled += instance.OnRemoveWeapon;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Inventory;
    private readonly InputAction m_UI_UseItem;
    private readonly InputAction m_UI_DropItem;
    public struct UIActions
    {
        private @InputActions m_Wrapper;
        public UIActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_UI_Inventory;
        public InputAction @UseItem => m_Wrapper.m_UI_UseItem;
        public InputAction @DropItem => m_Wrapper.m_UI_DropItem;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @UseItem.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUseItem;
                @DropItem.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDropItem;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Test;
    public struct DebugActions
    {
        private @InputActions m_Wrapper;
        public DebugActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test => m_Wrapper.m_Debug_Test;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Test.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDefence(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRemoveWeapon(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnInventory(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnTest(InputAction.CallbackContext context);
    }
}
