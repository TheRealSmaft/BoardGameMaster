using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    
    protected bool _active = false;
    public bool active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
        }
    }

    public int actionLimit;
    public bool actionLimited = true;

    protected Player player;

    public virtual void Init()
    {
        if(!_active)
        {
            return;
        }
    }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    protected virtual void PerformAction()
    {
        if(actionLimited)
        {
            if (actionLimit > 0)
            {
                actionLimit--;
            }
        }
    }
}
