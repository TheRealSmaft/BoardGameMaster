using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : PlayerAction {

    public Die diePrefab;
    public int diceCount;

    private DiceManager diceManager;
    private List<Die> dice = new List<Die>();
    private bool diceRolling;

    public override void Init()
    {
        base.Init();
        diceManager = gameObject.AddComponent<DiceManager>();
        diceManager.AssignPlayer(player);
    }

    private void Update()
    {
        if (_active)
        {
            if (Input.GetButtonDown("Fire1") && !diceRolling && actionLimit > 0)
            {
                RollDice();
                diceRolling = true;
            }

            if (diceRolling)
            {
                foreach (Die die in dice)
                {
                    if (die.dieValue == 0)
                    {
                        break;
                    }

                    if (dice.IndexOf(die) + 1 >= dice.Count)
                    {
                        diceRolling = false;
                        diceManager.SubmitDice(dice);
                    }
                }
            }
        }
    }

    public void RollDice()
    {
        actionLimit--;
        if(dice.Count > 0)
        {
            diceManager.DestroyUnselectedDice();
        }

        int diceToInstantiate = diceCount - diceManager.GetSelectedDiceCount();
        if (diceToInstantiate > 0)
        {
            StartCoroutine(InstantiateDice(diceToInstantiate));
        }

        if (actionLimit <= 0)
        {
            this.enabled = false;
        }
    }

    private IEnumerator InstantiateDice(int diceToInstantiate)
    {
        for (int i = 0; i < diceToInstantiate; i++)
        {
            Die die = Instantiate(diePrefab, player.transform);
            dice.Add(die);
            die.AssignPlayer(player);
            die.transform.Translate(Vector3.up, Space.World);
            die.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            yield return new WaitForSeconds(.05f);
        }
    }
}
