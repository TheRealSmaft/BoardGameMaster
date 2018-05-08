using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : MonoBehaviour {
    
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
}
