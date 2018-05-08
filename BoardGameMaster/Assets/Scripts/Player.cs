using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private IPlayable game;

    public void AssignGame(IPlayable g)
    {
        game = g;
        game.AddRelevantPlayerActionScripts(this);
    }

    public void ToggleBehaviorScript(string action, bool active)
    {
        try
        {
            MonoBehaviour script = GetComponent(action) as MonoBehaviour;
            script.enabled = active;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Debug.Log(action + " is not a script attached to " + this.name + "!");
        }
    }

    
}
