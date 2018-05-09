using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    private Canvas ui;
    private Transform opponentPanel;
    private Transform playerPanel;
    private Transform controlPanel;

    public OpponentPanelPlayerEntry opponentPanelPlayerEntryPrefab;
    private List<OpponentPanelPlayerEntry> opponentPanelPlayerEntries = new List<OpponentPanelPlayerEntry>();

    private void Awake()
    {
        ui = GetComponentInChildren<Canvas>();
        opponentPanel = transform.Find("OpponentPanel");
        playerPanel = transform.Find("PlayerPanel");
        controlPanel = transform.Find("ControlPanel");
    }

    public void PopulateOpponentPanel(List<Player> players)
    {
        foreach(Player p in players)
        {
            OpponentPanelPlayerEntry pe = Instantiate(opponentPanelPlayerEntryPrefab, opponentPanel);
            
            pe.SetPlayerName(p.playerName);
        }
    }

    public void PopulatePlayerPanel()
    {

    }

    public void PopulateControlPanel()
    {

    }
}
