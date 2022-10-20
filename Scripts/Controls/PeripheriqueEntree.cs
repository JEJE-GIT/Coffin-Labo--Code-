// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/PeripheriqueEntree.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PeripheriqueEntree : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PeripheriqueEntree()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PeripheriqueEntree"",
    ""maps"": [
        {
            ""name"": ""PersonnageAuSol"",
            ""id"": ""b2f6f8f9-9998-463a-803b-2fd19e7039e7"",
            ""actions"": [
                {
                    ""name"": ""Marcher"",
                    ""type"": ""Value"",
                    ""id"": ""0785c623-456f-40c7-ad9d-d65fdd0ad42b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Courir"",
                    ""type"": ""Button"",
                    ""id"": ""adcc7c14-572c-4aa5-8e9f-ead742c375b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sauter"",
                    ""type"": ""Button"",
                    ""id"": ""581c6099-79e9-4256-bc9c-02c4649b73b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Regarder"",
                    ""type"": ""Value"",
                    ""id"": ""2ab6ed54-9855-49e3-9b69-05601120c9d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cliquer"",
                    ""type"": ""Button"",
                    ""id"": ""9c0e95f2-fd2c-4496-85d2-7e3eca8ff09b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangerCamera"",
                    ""type"": ""Button"",
                    ""id"": ""c07bd5d8-5882-4c7b-b6ab-aeab61ce89a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e58e23df-f663-474f-8cd3-61f49959cc18"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Courir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c3b2198-58c8-4eaa-a387-c9c0d3e3e1e7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Courir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e6c472f-51e2-40f0-a09a-ad241f9da6fe"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0a272459-1e81-4a29-a7c7-70b4feb4e340"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e165f603-c6be-4d36-be45-0aeff69825ba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""558e5380-6754-4195-a9ef-12fa81d1612d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2476c277-852e-438c-b1ce-a420c0a317fe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dd48d90c-b7d6-4ccc-890a-5d579aeb36e7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""FLECHE"",
                    ""id"": ""d459ca40-dbe0-46bc-aef8-bf2a8cf3b3c7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""71e39525-423b-4db6-bcce-96752eb90fed"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""19668cbf-9145-4dab-992e-24ca07ceaf85"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9076ab5c-7004-4e2c-a505-841bd6f0fcde"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3284f873-c2bb-4bda-b553-f8a4f5eaa3d6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Marcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7f651e4-0c78-4b70-94b2-059b31763520"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cliquer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15d8dc53-33cc-4ef5-af7c-4b676290de1c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cliquer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e3337b7-db80-4963-9b48-47006cb962ae"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Regarder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b33105-fd3c-4b63-9aa4-8fd0eec93586"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Regarder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a37b9a54-edea-49bd-a11f-675d2a122b60"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sauter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34665869-d87c-464c-b36c-40941575e886"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sauter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe3e2b13-9cdb-4269-bcdf-214c28365c5a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangerCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9dd6a5d-8104-4ec9-ac49-03d853fc6837"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangerCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""1b8e665a-8e92-4b20-9115-a7c35e1d357b"",
            ""actions"": [
                {
                    ""name"": ""Cliquer"",
                    ""type"": ""Button"",
                    ""id"": ""8531d6fa-61c4-408e-b0a8-7e2709d60c16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quitter"",
                    ""type"": ""Button"",
                    ""id"": ""adf4202a-84ed-4ab0-9086-715add7acf94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ecrire"",
                    ""type"": ""Button"",
                    ""id"": ""acfdd4b7-3fbb-467f-be67-9ac6081ab1a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeplacerCurseur"",
                    ""type"": ""Value"",
                    ""id"": ""d15c8b45-b8f6-419d-98b7-b33d2b0fcdb1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b784c61-20d8-41a0-b41d-11bab033bc85"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cliquer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af41c658-9214-4466-b1ed-1167801291c3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cliquer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b336ee16-34cb-438f-9aab-34f7ae52efd9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quitter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5adb4439-9a40-47ba-9ece-a0f90cae5956"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quitter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8218f66-e33f-46c3-a08f-08ad679f657f"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ecrire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""705132a9-bd9c-4ded-a394-851fa2077e5d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeplacerCurseur"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d66cce4-e7f9-4dda-9398-37c38422c51f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeplacerCurseur"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PersonnageAuSol
        m_PersonnageAuSol = asset.FindActionMap("PersonnageAuSol", throwIfNotFound: true);
        m_PersonnageAuSol_Marcher = m_PersonnageAuSol.FindAction("Marcher", throwIfNotFound: true);
        m_PersonnageAuSol_Courir = m_PersonnageAuSol.FindAction("Courir", throwIfNotFound: true);
        m_PersonnageAuSol_Sauter = m_PersonnageAuSol.FindAction("Sauter", throwIfNotFound: true);
        m_PersonnageAuSol_Regarder = m_PersonnageAuSol.FindAction("Regarder", throwIfNotFound: true);
        m_PersonnageAuSol_Cliquer = m_PersonnageAuSol.FindAction("Cliquer", throwIfNotFound: true);
        m_PersonnageAuSol_ChangerCamera = m_PersonnageAuSol.FindAction("ChangerCamera", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Cliquer = m_UI.FindAction("Cliquer", throwIfNotFound: true);
        m_UI_Quitter = m_UI.FindAction("Quitter", throwIfNotFound: true);
        m_UI_Ecrire = m_UI.FindAction("Ecrire", throwIfNotFound: true);
        m_UI_DeplacerCurseur = m_UI.FindAction("DeplacerCurseur", throwIfNotFound: true);
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

    // PersonnageAuSol
    private readonly InputActionMap m_PersonnageAuSol;
    private IPersonnageAuSolActions m_PersonnageAuSolActionsCallbackInterface;
    private readonly InputAction m_PersonnageAuSol_Marcher;
    private readonly InputAction m_PersonnageAuSol_Courir;
    private readonly InputAction m_PersonnageAuSol_Sauter;
    private readonly InputAction m_PersonnageAuSol_Regarder;
    private readonly InputAction m_PersonnageAuSol_Cliquer;
    private readonly InputAction m_PersonnageAuSol_ChangerCamera;
    public struct PersonnageAuSolActions
    {
        private @PeripheriqueEntree m_Wrapper;
        public PersonnageAuSolActions(@PeripheriqueEntree wrapper) { m_Wrapper = wrapper; }
        public InputAction @Marcher => m_Wrapper.m_PersonnageAuSol_Marcher;
        public InputAction @Courir => m_Wrapper.m_PersonnageAuSol_Courir;
        public InputAction @Sauter => m_Wrapper.m_PersonnageAuSol_Sauter;
        public InputAction @Regarder => m_Wrapper.m_PersonnageAuSol_Regarder;
        public InputAction @Cliquer => m_Wrapper.m_PersonnageAuSol_Cliquer;
        public InputAction @ChangerCamera => m_Wrapper.m_PersonnageAuSol_ChangerCamera;
        public InputActionMap Get() { return m_Wrapper.m_PersonnageAuSol; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PersonnageAuSolActions set) { return set.Get(); }
        public void SetCallbacks(IPersonnageAuSolActions instance)
        {
            if (m_Wrapper.m_PersonnageAuSolActionsCallbackInterface != null)
            {
                @Marcher.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnMarcher;
                @Marcher.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnMarcher;
                @Marcher.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnMarcher;
                @Courir.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCourir;
                @Courir.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCourir;
                @Courir.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCourir;
                @Sauter.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnSauter;
                @Sauter.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnSauter;
                @Sauter.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnSauter;
                @Regarder.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnRegarder;
                @Regarder.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnRegarder;
                @Regarder.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnRegarder;
                @Cliquer.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCliquer;
                @Cliquer.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCliquer;
                @Cliquer.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnCliquer;
                @ChangerCamera.started -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnChangerCamera;
                @ChangerCamera.performed -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnChangerCamera;
                @ChangerCamera.canceled -= m_Wrapper.m_PersonnageAuSolActionsCallbackInterface.OnChangerCamera;
            }
            m_Wrapper.m_PersonnageAuSolActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Marcher.started += instance.OnMarcher;
                @Marcher.performed += instance.OnMarcher;
                @Marcher.canceled += instance.OnMarcher;
                @Courir.started += instance.OnCourir;
                @Courir.performed += instance.OnCourir;
                @Courir.canceled += instance.OnCourir;
                @Sauter.started += instance.OnSauter;
                @Sauter.performed += instance.OnSauter;
                @Sauter.canceled += instance.OnSauter;
                @Regarder.started += instance.OnRegarder;
                @Regarder.performed += instance.OnRegarder;
                @Regarder.canceled += instance.OnRegarder;
                @Cliquer.started += instance.OnCliquer;
                @Cliquer.performed += instance.OnCliquer;
                @Cliquer.canceled += instance.OnCliquer;
                @ChangerCamera.started += instance.OnChangerCamera;
                @ChangerCamera.performed += instance.OnChangerCamera;
                @ChangerCamera.canceled += instance.OnChangerCamera;
            }
        }
    }
    public PersonnageAuSolActions @PersonnageAuSol => new PersonnageAuSolActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Cliquer;
    private readonly InputAction m_UI_Quitter;
    private readonly InputAction m_UI_Ecrire;
    private readonly InputAction m_UI_DeplacerCurseur;
    public struct UIActions
    {
        private @PeripheriqueEntree m_Wrapper;
        public UIActions(@PeripheriqueEntree wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cliquer => m_Wrapper.m_UI_Cliquer;
        public InputAction @Quitter => m_Wrapper.m_UI_Quitter;
        public InputAction @Ecrire => m_Wrapper.m_UI_Ecrire;
        public InputAction @DeplacerCurseur => m_Wrapper.m_UI_DeplacerCurseur;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Cliquer.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCliquer;
                @Cliquer.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCliquer;
                @Cliquer.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCliquer;
                @Quitter.started -= m_Wrapper.m_UIActionsCallbackInterface.OnQuitter;
                @Quitter.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnQuitter;
                @Quitter.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnQuitter;
                @Ecrire.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEcrire;
                @Ecrire.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEcrire;
                @Ecrire.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEcrire;
                @DeplacerCurseur.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDeplacerCurseur;
                @DeplacerCurseur.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDeplacerCurseur;
                @DeplacerCurseur.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDeplacerCurseur;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cliquer.started += instance.OnCliquer;
                @Cliquer.performed += instance.OnCliquer;
                @Cliquer.canceled += instance.OnCliquer;
                @Quitter.started += instance.OnQuitter;
                @Quitter.performed += instance.OnQuitter;
                @Quitter.canceled += instance.OnQuitter;
                @Ecrire.started += instance.OnEcrire;
                @Ecrire.performed += instance.OnEcrire;
                @Ecrire.canceled += instance.OnEcrire;
                @DeplacerCurseur.started += instance.OnDeplacerCurseur;
                @DeplacerCurseur.performed += instance.OnDeplacerCurseur;
                @DeplacerCurseur.canceled += instance.OnDeplacerCurseur;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPersonnageAuSolActions
    {
        void OnMarcher(InputAction.CallbackContext context);
        void OnCourir(InputAction.CallbackContext context);
        void OnSauter(InputAction.CallbackContext context);
        void OnRegarder(InputAction.CallbackContext context);
        void OnCliquer(InputAction.CallbackContext context);
        void OnChangerCamera(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnCliquer(InputAction.CallbackContext context);
        void OnQuitter(InputAction.CallbackContext context);
        void OnEcrire(InputAction.CallbackContext context);
        void OnDeplacerCurseur(InputAction.CallbackContext context);
    }
}
