using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private IPlayable game;
    private Dictionary<string, int> actionTracker = new Dictionary<string, int>();

    private void Start()
    {
        actionTracker.Clear();
    }

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

    public void AcknowledgeAction(string action)
    {
        if(actionTracker.ContainsKey(action))
        {
            actionTracker[action]++;
        }
        else
        {
            actionTracker.Add(action, 1);
        }

        game.EvaluateTurnActions(this);
    }

    public Dictionary<string, int> GetPlayerActions()
    {
        return actionTracker;
    }

    // Dice only

    public void SubmitDice(List<Die> dice)
    {

    }
}
