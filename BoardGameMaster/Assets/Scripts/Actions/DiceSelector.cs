using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSelector : PlayerAction {

    public override void Init()
    {
        base.Init();
    }

    private void Update()
    {
        if(_active)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                Transform obj = BGMGlobal.GetClickedGameObject();
                if(obj.tag == "Die")
                {
                    player.GetComponentInChildren<DiceManager>().ToggleDieSelection(obj.GetComponent<Die>());
                }
            }
        }
    }
}
