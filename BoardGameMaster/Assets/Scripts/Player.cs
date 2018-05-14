using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string playerName;
    private IPlayable game;

    public DiceManager diceManager;

    public void AssignGame(IPlayable g)
    {
        game = g;
    }

    public void EndPlayerTurn()
    {
        game.EndPlayerTurn(this);
    }
}
