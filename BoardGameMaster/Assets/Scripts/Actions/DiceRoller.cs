using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour {

    public int turnActionLimit;
    public Die diePrefab;
    public int diceCount;

    private Player player;
    private DiceManager diceManager;
    private List<Die> dice = new List<Die>();
    private bool diceRolling;

    private void Awake()
    {
        player = GetComponent<Player>();
        diceManager = gameObject.AddComponent<DiceManager>();
        diceManager.AssignPlayer(player);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !diceRolling && turnActionLimit > 0)
        {
            RollDice();
            diceRolling = true;
        }

        if(diceRolling)
        {
            foreach(Die die in dice)
            {
                if(die.dieValue == 0)
                {
                    break;
                }

                if(dice.IndexOf(die) + 1 >= dice.Count)
                {
                    diceRolling = false;
                    diceManager.SubmitDice(dice);
                }
            }
        }
    }

    public void RollDice()
    {
        turnActionLimit--;
        StartCoroutine(InstantiateDice());

        if (turnActionLimit <= 0)
        {
            this.enabled = false;
        }
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
