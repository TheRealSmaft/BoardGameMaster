using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string playerName;
    private IPlayable game;

    public void AssignGame(IPlayable g)
    {
        game = g;
        game.actionScriptManager.AddRelevantPlayerActionScripts(this);
    }

    public void ToggleBehaviorScript<T>(T action, bool active) where T : PlayerAction
    {
        try
        {
            MonoBehaviour script = GetComponentInChildren<T>() as MonoBehaviour;
            script.enabled = active;
            script.GetComponent<T>().active = active;
            script.GetComponent<T>().Init();

        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Debug.Log(action.ToString() + " is not a script attached to " + this.name + "!");
        }
    }

    public void EndPlayerTurn()
    {
        game.EndPlayerTurn(this);
    }
}
