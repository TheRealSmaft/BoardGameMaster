using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable {

    void SetupGame(GameMaster gm);
    void StartGame(Player p);
    void EndGame();
    void StartPlayerTurn(Player p);
    void EndPlayerTurn(Player p);
    void CheckForWinner();
}
