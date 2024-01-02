using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreatePrivateRoomController
{
    void CreateRoom(GameMode mode, string field , string key);
}
