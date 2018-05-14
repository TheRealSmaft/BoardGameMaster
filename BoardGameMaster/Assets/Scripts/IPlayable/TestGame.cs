using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour, IDicePlayable {

    private GameMaster _gameMaster;
    private GameUI _gameUI;

    public PlayerAction[] playerActions;

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

    public void SetupGame(GameMaster gm, GameUI gui)
    {
        gameMaster = gm;
        gameUI = gui;
    }

    public void StartGame(Player p)
    {
        StartPlayerTurn(p);
    }

    public void StartPlayerTurn(Player p)
    {
        p.gameObject.SetActive(true);
        gameUI.SetPlayer(p);
        foreach (PlayerAction pa in playerActions)
        {
            pa.AssignPlayer(p);
        }
    }

    public void EndPlayerTurn(Player p)
    {
        p.gameObject.SetActive(false);
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
    }
}
