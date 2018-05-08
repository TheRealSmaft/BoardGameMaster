using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScriptManager : MonoBehaviour {

    public Component[] actionScripts;

    public void AddRelevantPlayerActionScripts(Player p)
    {
        foreach (Component c in actionScripts)
        {
            AddScriptToPlayer<Component>(c, p.gameObject);
        }
    }

    private void AddScriptToPlayer<T>(T action, GameObject p) where T : Component
    {
        System.Type type = action.GetType();
        Component clone = p.AddComponent(type);

        System.Reflection.FieldInfo[] fields = type.GetFields();

        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(clone, field.GetValue(action));
        }
    }
}
