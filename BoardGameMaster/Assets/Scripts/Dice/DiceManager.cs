using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    private IDicePlayable game;
    private Player player;
    private List<Die> unselectedDice;
    private List<Die> selectedDice = new List<Die>();

    private void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<IPlayable>() as IDicePlayable;
    }

    public void AssignPlayer(Player p)
    {
        player = p;
    }

    public void SubmitDice(List<Die> dl)
    {
        unselectedDice = dl;
        game.ActivatePostDiceRollActions(player);
    }

    public List<Die> GetAllDice()
    {
        List<Die> allDice = new List<Die>();
        allDice.AddRange(selectedDice);
        allDice.AddRange(unselectedDice);
        return allDice;
    }

    public void ToggleDieSelection(Die die)
    {
        if(selectedDice.Contains(die))
        {
            selectedDice.Remove(die);
            unselectedDice.Add(die);
            die.ToggleSelected(false);
        }
        else if(unselectedDice.Contains(die))
        {
            unselectedDice.Remove(die);
            selectedDice.Add(die);
            die.ToggleSelected(true);
        }
    }

    public void DestroyUnselectedDice()
    {
        foreach(Die die in unselectedDice)
        {
            if (!selectedDice.Contains(die))
            {
                die.DestroyDie();
            }
        }
        unselectedDice.Clear();
    }

    public int GetSelectedDiceCount()
    {
        return selectedDice.Count;
    }
}
