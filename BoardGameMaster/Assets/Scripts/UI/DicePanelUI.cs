using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePanelUI : MonoBehaviour {

    public DieButtonUI[] diceButtons;

    public void UpdateDicePanel(Player p)
    {
        List<Die> dice = p.GetComponent<DiceManager>().GetAllDice();
        for (int i = 0; i < diceButtons.Length; i++)
        {
            diceButtons[i].AssignDie(dice[i]);
        }
    }
}
