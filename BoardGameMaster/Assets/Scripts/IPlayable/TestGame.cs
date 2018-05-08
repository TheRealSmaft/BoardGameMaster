using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour, IPlayable {

    private GameMaster gameMaster;
    private Dictionary<string, int> playerTurnActionLimits = new Dictionary<string, int>();

    public Component[] playerActionScripts;

    private void Awake()
    {
        playerTurnActionLimits.Add("DiceRoller", 3);
    }

    public void SetupGame(GameMaster gm)
    {
        gameMaster = gm;
        Debug.Log("SETUP");
    }

    public void AddRelevantPlayerActionScripts(Player p)
    {
        foreach(Component c in playerActionScripts)
        {
            AddScriptToPlayer<Component>(c, p.gameObject);
        }
    }

    private void AddScriptToPlayer<T>(T action, GameObject p) where T : Component
    {
        Type type = action.GetType();
        Component clone = p.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();

        foreach(System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(clone, field.GetValue(action));
        }
    }

    public void StartGame(Player p)
    {
        Debug.Log("Start Game");
        StartPlayerTurn(p);
    }

    public void StartPlayerTurn(Player p)
    {
        Debug.Log("Start Player Turn");
        p.gameObject.SetActive(true);
        p.ToggleBehaviorScript("DiceRoller", true);
    }

    public void EndPlayerTurn(Player p)
    {
        p.gameObject.SetActive(false);
        p.ToggleBehaviorScript("DiceRoller", false);
        StartPlayerTurn(gameMaster.GetNextPlayer(p));
    }

    public void EvaluateTurnActions(Player p)
    {
        Dictionary<string, int> playerActions = p.GetPlayerActions();

        foreach(KeyValuePair<string, int> action in playerActions)
        {
            if(playerTurnActionLimits.ContainsKey(action.Key))
            {
                if(action.Value >= playerTurnActionLimits[action.Key])
                {
                    EndPlayerTurn(p);
                }
            }
        }
    }

    public void CheckIfGameShouldEnd()
    {
        
    }

    public void EndGame()
    {
        
    }
}
