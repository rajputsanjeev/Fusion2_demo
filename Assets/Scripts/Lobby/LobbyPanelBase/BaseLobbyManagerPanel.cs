using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseLobbyManagerPanel : LobbyPanelBase
{
    [SerializeField] private Button cancelBtn;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);
        cancelBtn.onClick.AddListener(() => { CloseCurrentPanel(); });
    }

    private void CloseCurrentPanel()
    {
        base.ClosePanel();
        lobbyUIManager.ShowPanel(LobbyPanelType.SessionListPanel);
    }
}
