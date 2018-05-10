using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScriptManager : MonoBehaviour {

    public void AddRelevantPlayerActionScripts(Player p)
    {
        PlayerAction[] playerActions = GetComponents<PlayerAction>();
        foreach (PlayerAction action in playerActions)
        {
            AddScriptToPlayer(action, p.gameObject);
        }
    }

    private void AddScriptToPlayer<T>(T action, GameObject p) where T : PlayerAction
    {
        System.Type type = action.GetType();
        PlayerAction clone = p.AddComponent(type) as PlayerAction;

        System.Reflection.FieldInfo[] fields = type.GetFields();

        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(clone, field.GetValue(action));
        }
    }
}
