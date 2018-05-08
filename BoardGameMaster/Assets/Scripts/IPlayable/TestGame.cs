using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour, IPlayable {

    private GameMaster gameMaster;

    public void SetupGame(GameMaster gm)
    {
        gameMaster = gm;
        Debug.Log("SETUP");
    }

    public void StartGame(Player p)
    {
        Debug.Log("Start Game");
        StartPlayerTurn(p);
    }

    public void StartPlayerTurn(Player p)
    {
        Debug.Log("Start Player Turn");

    }

    public void EndPlayerTurn(Player p)
    {
        
    }

    public void CheckForWinner()
    {
        
    }

    public void EndGame()
    {
        
    }
}
