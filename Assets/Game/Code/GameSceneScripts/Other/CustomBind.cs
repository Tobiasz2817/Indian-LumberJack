using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEditor;
using Debug = UnityEngine.Debug;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif


[DisplayStringFormat("{Button}")]
public class CustomBind : InputBindingComposite<float>
{
    [InputControl(layout = "Button")] 
    public int buttonA;


    public override float ReadValue(ref InputBindingCompositeContext context)
    {
        var firstPartValue = context.ReadValue<float>(buttonA);

        Debug.Log(firstPartValue);

        if (firstPartValue == 1)
        {
            return firstPartValue;
        }
        else return 0;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        return base.EvaluateMagnitude(ref context);
    }

    static CustomBind()
    {
        InputSystem.RegisterBindingComposite<CustomBind>();
    }

    [RuntimeInitializeOnLoadMethod]
    static void Init() {}
}
