using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable {

    GameMaster gameMaster { get; }
    ActionScriptManager actionScriptManager { get; }

    void SetupGame(GameMaster gm);
    void StartGame(Player p);
    void EndGame();
    void StartPlayerTurn(Player p);
    void EndPlayerTurn(Player p);
    void EvaluateTurnActions(Player p);
    void CheckIfGameShouldEnd();
}
