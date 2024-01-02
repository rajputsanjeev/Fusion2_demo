using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    public LobbyPanelBase.LobbyPanelType firstUI = LobbyPanelBase.LobbyPanelType.None;

    [SerializeField] private LobbyPanelBase[] lobbyPanels;

    private void Start()
    {
        foreach (var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }

        ShowPanel(firstUI);
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        ClosePanelAllPanel();

        foreach (var lobby in lobbyPanels)
        {
            if (lobby.PanelType == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }

    public void ClosePanelAllPanel()
    {
        foreach (var lobby in lobbyPanels)
        {
           lobby.ClosePanel();
        }
    }
}