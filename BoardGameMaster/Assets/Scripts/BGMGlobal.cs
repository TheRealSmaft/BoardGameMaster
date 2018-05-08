using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BGMGlobal {

	public static Transform GetClickedGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform;
        }
        else
        {
            return null;
        }
    }
}
