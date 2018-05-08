using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour {

    public Die diePrefab;
    public int diceCount;

    private Player player;
    private List<Die> dice = new List<Die>();
    private bool diceRolling;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !diceRolling)
        {
            RollDice();
            diceRolling = true;
        }

        if(diceRolling)
        {
            foreach(Die die in dice)
            {
                if(die.value == 0)
                {
                    break;
                }

                if(dice.IndexOf(die) + 1 >= dice.Count)
                {
                    diceRolling = false;
                    player.SubmitDice(dice);
                }
            }
        }
    }

    public void RollDice()
    {
        player.AcknowledgeAction("DiceRoller");
        StartCoroutine(InstantiateDice());
    }

    private IEnumerator InstantiateDice()
    {
        for (int i = 0; i < diceCount; i++)
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
