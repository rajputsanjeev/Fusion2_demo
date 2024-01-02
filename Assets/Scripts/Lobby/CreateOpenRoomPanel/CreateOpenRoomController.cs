using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOpenRoomController : LobbyBaseController, ICreateOpenRoomController
{
    protected ICreateOpenRoomPanel createOpenRoomPanel;

    protected override void Awake()
    {
        base.Awake();
        createOpenRoomPanel = GetComponent<ICreateOpenRoomPanel>();
        createOpenRoomPanel.Init(this);
    }

    public void CreateRoom(GameMode mode, string field)
    {
        networkRunnerController.StartGame(mode, field);
    }
}
