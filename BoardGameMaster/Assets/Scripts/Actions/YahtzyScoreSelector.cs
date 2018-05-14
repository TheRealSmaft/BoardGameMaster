using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YahtzyScoreSelector : PlayerAction {

    public override void PerformAction()
    {
        base.PerformAction();
        player.EndPlayerTurn();
    }
}
