using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    private IDicePlayable game;
    private Player player;
    private List<Die> dice;
    private List<Die> selectedDice = new List<Die>();

    private void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameMaster").GetComponentInChildren<IPlayable>() as IDicePlayable;
    }

    public void AssignPlayer(Player p)
    {
        player = p;
    }

    public void SubmitDice(List<Die> dl)
    {
        dice = dl;
        game.ActivateDiceActions(player);
    }

    public void ToggleDieSelection(Die die)
    {
        if(dice.Contains(die))
        {
            if(selectedDice.Contains(die))
            {
                selectedDice.Remove(die);
            }
            else
            {
                selectedDice.Add(die);
            }
        }
    }
}
