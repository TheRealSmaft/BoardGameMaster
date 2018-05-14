using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSelector : PlayerAction {

    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            PerformAction();
        }
    }

    public override void PerformAction()
    {
        base.PerformAction();
        SelectDie();
    }

    private void SelectDie()
    {
        Transform obj = BGMGlobal.GetClickedGameObject();
        if (obj.tag == "Die")
        {
            player.GetComponent<DiceManager>().ToggleDieSelection(obj.GetComponent<Die>());
        }
    }
}
