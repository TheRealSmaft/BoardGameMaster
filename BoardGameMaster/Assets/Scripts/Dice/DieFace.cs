using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFace : MonoBehaviour {

    public Die die;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DieDropZone")
        {
            die.SetFace(int.Parse(gameObject.name));
        }
    }
}
