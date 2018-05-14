using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int dieValue = 0;
    public Material[] materials;

    private int face;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private Vector3 rollPosition;
    private float rerollCountdown = 6f;
    private bool selected = false;

    private void Start()
    {
        rollPosition = transform.position;
        meshRenderer = GetComponent<MeshRenderer>();
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
    
    public void SetFace(int f)
    {
        face = f;
    }

    public void Reroll()
    {
        transform.position = rollPosition;
        rerollCountdown = 6f;
    }

    public void ToggleSelected(bool select)
    {
        if(selected != select)
        {
            selected = select;
            Material[] mats = meshRenderer.materials;
            mats[0] = materials[!selected ? 0 : 1];
            meshRenderer.materials = mats;
        }
    }

    public void DestroyDie()
    {
        Destroy(gameObject);
    }
}