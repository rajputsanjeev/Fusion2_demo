using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoomWithNameController : LobbyBaseController, IJoinRoomWithNameController
{
    protected IJoinRoomWithNamePanel joinRoomWithNamePanel;

    protected override void Awake()
    {
        base.Awake();
        joinRoomWithNamePanel = GetComponent<IJoinRoomWithNamePanel>();
        joinRoomWithNamePanel.Init(this);
    }

    public void JoinRoomWithName(GameMode mode, string field)
    {
        networkRunnerController.StartGame(mode, field);
    }
}
