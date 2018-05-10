using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YahtzyScoreSelector : PlayerAction {

    private void Update()
    {
        if(_active)
        {
            if(Input.GetButtonDown("Jump"))
            {
                PerformAction();
            }
        }
    }

    protected override void PerformAction()
    {
        base.PerformAction();
        player.EndPlayerTurn();
    }
}
