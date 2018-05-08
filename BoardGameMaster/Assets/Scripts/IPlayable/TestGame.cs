using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour, IDicePlayable {

    private GameMaster gameMaster;
    public ActionScriptManager actionScriptManager;
    
    public void SetupGame(GameMaster gm)
    {
        gameMaster = gm;
        Debug.Log("SETUP");
    }

    public void AddRelevantPlayerActionScripts(Player p)
    {
        foreach(Component c in actionScriptManager.actionScripts)
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
        p.ToggleBehaviorScript<DiceRoller>(p.GetComponentInChildren<DiceRoller>(), true);
    }

    public void EndPlayerTurn(Player p)
    {
        p.gameObject.SetActive(false);
        p.ToggleBehaviorScript<DiceRoller>(p.GetComponentInChildren<DiceRoller>(), false);
        StartPlayerTurn(gameMaster.GetNextPlayer(p));
    }

    public void EvaluateTurnActions(Player p)
    {
        
    }

    public void CheckIfGameShouldEnd()
    {
        
    }

    public void EndGame()
    {
        
    }

    public void ActivateDiceActions(Player p)
    {
        p.ToggleBehaviorScript<DiceSelector>(p.GetComponentInChildren<DiceSelector>(), true);
    }
}
