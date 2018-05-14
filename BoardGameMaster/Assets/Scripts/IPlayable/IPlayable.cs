using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable {

    GameUI gameUI { get; }
    GameMaster gameMaster { get; }

    void SetupGame(GameMaster gm, GameUI gui);
    void StartGame(Player p);
    void EndGame();
    void StartPlayerTurn(Player p);
    void EndPlayerTurn(Player p);
    void EvaluateTurnActions(Player p);
    void CheckIfGameShouldEnd();
}
