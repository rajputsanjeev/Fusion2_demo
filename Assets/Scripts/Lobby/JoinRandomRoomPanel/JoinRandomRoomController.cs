using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRandomRoomController : LobbyBaseController, IJoinRandomRoomController
{
    protected IJoinRandomRoomPanel joinRandomRoomPanel;

    protected override void Awake()
    {
        base.Awake();
        joinRandomRoomPanel = GetComponent<IJoinRandomRoomPanel>();
        joinRandomRoomPanel.Init(this);
    }

    public void JoinRandomRoom()
    {
        networkRunnerController.StartGame(GameMode.Client, string.Empty);
    }
}
