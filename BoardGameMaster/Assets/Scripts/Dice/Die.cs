using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int dieValue = 0;
    private int face;
    private Player player;
    private Rigidbody rb;
    private float rerollCountdown = 6f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(0f, 600f), Random.Range(0f, 600f), Random.Range(0f, 600f)));
    }

    private void Update()
    {
        if(rb.velocity == Vector3.zero && dieValue == 0)
        {
            dieValue = face;
        }

        if(rerollCountdown > 0f)
        {
            rerollCountdown -= Time.deltaTime;
        }
        else
        {
            if(dieValue == 0)
            {
                Reroll();
            }
        }
    }

    public void AssignPlayer(Player p)
    {
        player = p;
    }

    public void SetFace(int f)
    {
        face = f;
    }

    public void Reroll()
    {
        transform.position = player.transform.position + Vector3.up;
        rerollCountdown = 6f;
    }
}