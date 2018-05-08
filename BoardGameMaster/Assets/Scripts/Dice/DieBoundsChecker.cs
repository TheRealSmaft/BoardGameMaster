using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBoundsChecker : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Die")
        {
            other.GetComponentInChildren<Die>().Reroll();
        }
    }
}
