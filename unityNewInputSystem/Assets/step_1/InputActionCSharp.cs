//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/step_1/InputActionCSharp.inputactions
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

public partial class @InputActionCSharp: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionCSharp()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionCSharp"",
    ""maps"": [
        {
            ""name"": ""ActionmapsAxis"",
            ""id"": ""884551ff-a1de-4eee-8e27-a50a970a2a33"",
            ""actions"": [
                {
                    ""name"": ""DoMove_ForwardAxis"",
                    ""type"": ""Value"",
                    ""id"": ""85c8f06d-18a1-48bb-b544-70afa92a0ca9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DoRotate"",
                    ""type"": ""Value"",
                    ""id"": ""4f79cd3f-8708-429b-9e21-bd56b0c24de7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""700e3b3a-bcd3-4ba9-ae52-6c5b33f9bd55"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoMove_ForwardAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8edf50ae-c515-46c5-a1bd-1e7d602ee9ad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controlSchemaAxisPC"",
                    ""action"": ""DoMove_ForwardAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c8915eac-219f-404f-b434-685b4a5137c0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controlSchemaAxisPC"",
                    ""action"": ""DoMove_ForwardAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""96177fb9-c716-41c0-b23e-f671b8c3a89f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoRotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""79856df4-a243-4cc4-a991-bab4423012cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controlSchemaAxisPC"",
                    ""action"": ""DoRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7971f06a-2760-4297-b560-f2a1325fc60c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controlSchemaAxisPC"",
                    ""action"": ""DoRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controlSchemaAxisPC"",
            ""bindingGroup"": ""controlSchemaAxisPC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // ActionmapsAxis
        m_ActionmapsAxis = asset.FindActionMap("ActionmapsAxis", throwIfNotFound: true);
        m_ActionmapsAxis_DoMove_ForwardAxis = m_ActionmapsAxis.FindAction("DoMove_ForwardAxis", throwIfNotFound: true);
        m_ActionmapsAxis_DoRotate = m_ActionmapsAxis.FindAction("DoRotate", throwIfNotFound: true);
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

    // ActionmapsAxis
    private readonly InputActionMap m_ActionmapsAxis;
    private List<IActionmapsAxisActions> m_ActionmapsAxisActionsCallbackInterfaces = new List<IActionmapsAxisActions>();
    private readonly InputAction m_ActionmapsAxis_DoMove_ForwardAxis;
    private readonly InputAction m_ActionmapsAxis_DoRotate;
    public struct ActionmapsAxisActions
    {
        private @InputActionCSharp m_Wrapper;
        public ActionmapsAxisActions(@InputActionCSharp wrapper) { m_Wrapper = wrapper; }
        public InputAction @DoMove_ForwardAxis => m_Wrapper.m_ActionmapsAxis_DoMove_ForwardAxis;
        public InputAction @DoRotate => m_Wrapper.m_ActionmapsAxis_DoRotate;
        public InputActionMap Get() { return m_Wrapper.m_ActionmapsAxis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionmapsAxisActions set) { return set.Get(); }
        public void AddCallbacks(IActionmapsAxisActions instance)
        {
            if (instance == null || m_Wrapper.m_ActionmapsAxisActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionmapsAxisActionsCallbackInterfaces.Add(instance);
            @DoMove_ForwardAxis.started += instance.OnDoMove_ForwardAxis;
            @DoMove_ForwardAxis.performed += instance.OnDoMove_ForwardAxis;
            @DoMove_ForwardAxis.canceled += instance.OnDoMove_ForwardAxis;
            @DoRotate.started += instance.OnDoRotate;
            @DoRotate.performed += instance.OnDoRotate;
            @DoRotate.canceled += instance.OnDoRotate;
        }

        private void UnregisterCallbacks(IActionmapsAxisActions instance)
        {
            @DoMove_ForwardAxis.started -= instance.OnDoMove_ForwardAxis;
            @DoMove_ForwardAxis.performed -= instance.OnDoMove_ForwardAxis;
            @DoMove_ForwardAxis.canceled -= instance.OnDoMove_ForwardAxis;
            @DoRotate.started -= instance.OnDoRotate;
            @DoRotate.performed -= instance.OnDoRotate;
            @DoRotate.canceled -= instance.OnDoRotate;
        }

        public void RemoveCallbacks(IActionmapsAxisActions instance)
        {
            if (m_Wrapper.m_ActionmapsAxisActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionmapsAxisActions instance)
        {
            foreach (var item in m_Wrapper.m_ActionmapsAxisActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionmapsAxisActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionmapsAxisActions @ActionmapsAxis => new ActionmapsAxisActions(this);
    private int m_controlSchemaAxisPCSchemeIndex = -1;
    public InputControlScheme controlSchemaAxisPCScheme
    {
        get
        {
            if (m_controlSchemaAxisPCSchemeIndex == -1) m_controlSchemaAxisPCSchemeIndex = asset.FindControlSchemeIndex("controlSchemaAxisPC");
            return asset.controlSchemes[m_controlSchemaAxisPCSchemeIndex];
        }
    }
    public interface IActionmapsAxisActions
    {
        void OnDoMove_ForwardAxis(InputAction.CallbackContext context);
        void OnDoRotate(InputAction.CallbackContext context);
    }
}
