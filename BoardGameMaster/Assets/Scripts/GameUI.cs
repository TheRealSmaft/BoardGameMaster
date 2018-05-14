using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Button rollDiceButton;

    private Player player;

    public void SetPlayer(Player p)
    {
        player = p;
    }
}
