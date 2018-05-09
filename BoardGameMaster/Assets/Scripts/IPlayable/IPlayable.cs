using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable {

    GameMaster gameMaster { get; }
    GameUI gameUI { get; }
    ActionScriptManager actionScriptManager { get; }

    void SetupGame(GameMaster gm, GameUI ui);
    void StartGame(Player p);
    void EndGame();
    void StartPlayerTurn(Player p);
    void EndPlayerTurn(Player p);
    void EvaluateTurnActions(Player p);
    void CheckIfGameShouldEnd();
}
