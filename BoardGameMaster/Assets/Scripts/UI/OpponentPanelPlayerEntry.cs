using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentPanelPlayerEntry : MonoBehaviour {

    public Text playerNameText;

    public void SetPlayerName(string pn)
    {
        playerNameText.text = pn;
    }
}
