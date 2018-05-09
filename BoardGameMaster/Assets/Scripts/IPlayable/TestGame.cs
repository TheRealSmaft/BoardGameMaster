using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour, IDicePlayable {

    private GameMaster _gameMaster;
    private GameUI _gameUI;
    private ActionScriptManager _actionScriptManager;

    public GameMaster gameMaster
    {
        get
        {
            return _gameMaster;
        }
        private set
        {
            _gameMaster = value;
        }
    }

    public GameUI gameUI
    {
        get
        {
            return _gameUI;
        }
        private set
        {
            _gameUI = value;
        }
    }

    public ActionScriptManager actionScriptManager
    {
        get
        {
            return _actionScriptManager;
        }
        private set
        {
            _actionScriptManager = value;
        }
    }
    
    public void SetupGame(GameMaster gm, GameUI ui)
    {
        gameMaster = gm;
        gameUI = ui;
        actionScriptManager = GameObject.FindGameObjectWithTag("ActionScriptManager").GetComponent<ActionScriptManager>();
    }

    public void StartGame(Player p)
    {
        StartPlayerTurn(p);
    }

    public void StartPlayerTurn(Player p)
    {
        p.gameObject.SetActive(true);
        p.ToggleBehaviorScript(p.GetComponentInChildren<DiceRoller>(), true);
    }

    public void EndPlayerTurn(Player p)
    {
        p.gameObject.SetActive(false);
        p.ToggleBehaviorScript(p.GetComponentInChildren<DiceRoller>(), false);
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

    public void ActivatePostDiceRollActions(Player p)
    {
        p.ToggleBehaviorScript(p.GetComponentInChildren<DiceSelector>(), true);
    }
}
