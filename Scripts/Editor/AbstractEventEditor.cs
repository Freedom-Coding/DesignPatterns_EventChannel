using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableObject), true)]
public class AbstractEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScriptableObject scriptableObject = (ScriptableObject)target;

        Type type = scriptableObject.GetType();
        if (type.BaseType != null && type.BaseType.IsGenericType &&
            type.BaseType.GetGenericTypeDefinition() == typeof(AbstractEvent<>))
        {
            if (GUILayout.Button("Invoke"))
            {
                Type eventType = type.BaseType.GetGenericArguments()[0];
                FieldInfo valueField = type.BaseType.GetField("testingValue", BindingFlags.Public | BindingFlags.Instance);
                object value = valueField.GetValue(scriptableObject);

                MethodInfo method = type.GetMethod("Invoke");
                method?.Invoke(scriptableObject, new object[] { value });
            }
        }
    }
}