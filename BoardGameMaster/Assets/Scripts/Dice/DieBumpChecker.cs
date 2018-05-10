using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBumpChecker : MonoBehaviour {

    public Die die;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Die")
        {
            die.dieValue = 0;
        }
    }
}
