using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameUI gameUI;
    public List<Player> players;
    private IPlayable game;

    private void Awake()
    {
        game = GetComponentInChildren<IPlayable>();
        game.SetupGame(this, gameUI);

        foreach(Player p in players)
        {
            p.AssignGame(game);
        }
    }

    private void Start()
    {
        gameUI.PopulateOpponentPanel(players);
        game.StartGame(players[0]);
    }

    public Player GetNextPlayer(Player p)
    {
        if(players.Count < 2)
        {
            return p;
        }
        else if(players.IndexOf(p) + 1 >= players.Count)
        {
            return players[0];
        }
        else
        {
            return players[players.IndexOf(p) + 1];
        }
    }
}
