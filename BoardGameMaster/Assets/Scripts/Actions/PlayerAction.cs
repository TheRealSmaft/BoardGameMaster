using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    protected Player player;
    public int actionLimit;
    public bool isLimited;

    private int actionsRemaining;

    public void AssignPlayer(Player p)
    {
        player = p;
        ClearActions();
        this.enabled = true;
    }

    public virtual void PerformAction()
    {
        if(actionsRemaining > 0)
        {
            actionsRemaining--;
        }
        else
        {
            this.enabled = false;
        }
    }

    protected virtual void ClearActions()
    {
        actionsRemaining = actionLimit;
    }
}
