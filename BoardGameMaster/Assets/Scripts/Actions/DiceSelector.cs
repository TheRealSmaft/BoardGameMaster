using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSelector : PlayerAction {

    private void Update()
    {
        if(_active)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                PerformAction();
            }
        }
    }

    protected override void PerformAction()
    {
        base.PerformAction();
        SelectDie();
    }

    private void SelectDie()
    {
        Transform obj = BGMGlobal.GetClickedGameObject();
        if (obj.tag == "Die")
        {
            player.GetComponentInChildren<DiceManager>().ToggleDieSelection(obj.GetComponent<Die>());
        }
    }
}
