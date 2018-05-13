using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlexibleUIInstance : Editor {

    static GameObject clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = objectName;
        clickedObject = UnityEditor.Selection.activeObject as GameObject;
        if(clickedObject != null)
        {
            instance.transform.SetParent(clickedObject.transform, false);
        }
        return instance;
    }

    [MenuItem("GameObject/FlexibleUI/Button", priority = 0)]
    public static void AddButton()
    {
        Create("Button");
    }
}
