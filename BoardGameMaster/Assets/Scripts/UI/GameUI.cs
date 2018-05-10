using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    private Canvas ui;
    private RectTransform opponentPanel;
    private RectTransform playerPanel;
    private RectTransform controlPanel;

    public OpponentPanelPlayerEntry opponentPanelPlayerEntryPrefab;
    private List<OpponentPanelPlayerEntry> opponentPanelPlayerEntries = new List<OpponentPanelPlayerEntry>();

    private void Awake()
    {
        ui = GetComponentInChildren<Canvas>();
        opponentPanel = transform.Find("OpponentPanel") as RectTransform;
        playerPanel = transform.Find("PlayerPanel") as RectTransform;
        controlPanel = transform.Find("ControlPanel") as RectTransform;
    }

    public void PopulateOpponentPanel(List<Player> players)
    {
        float panelHeightOffset = opponentPanel.rect.height / 4f;

        foreach(Player p in players)
        {
            OpponentPanelPlayerEntry pe = Instantiate(opponentPanelPlayerEntryPrefab, opponentPanel);
            pe.GetComponentInChildren<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, (panelHeightOffset * players.IndexOf(p)), panelHeightOffset);
            pe.SetPlayerName(p.playerName);
            opponentPanelPlayerEntries.Add(pe);
        }
    }

    public void SetPlayerPanelName(string playerName)
    {
        Text pn = playerPanel.GetComponentInChildren<Text>();
        pn.text = playerName;
    }
    
    public void PopulateControlPanel()
    {

    }
}
