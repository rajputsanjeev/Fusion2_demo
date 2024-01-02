using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrivateRoomController : LobbyBaseController, ICreatePrivateRoomController
{
    protected ICreatePrivateRoomPanel createPrivateRoomPanel;

    protected override void Awake()
    {
        base.Awake();
        createPrivateRoomPanel = GetComponent<ICreatePrivateRoomPanel>();
        createPrivateRoomPanel.Init(this);
    }

    public void CreateRoom(GameMode mode, string field, string key)
    {
        SessionProperty keyValue = key;
        Dictionary<string, SessionProperty> sesssionProperty = new Dictionary<string, SessionProperty>();
        sesssionProperty.Add("key", keyValue);

        networkRunnerController.StartGame(mode, field, sesssionProperty);
    }
}
