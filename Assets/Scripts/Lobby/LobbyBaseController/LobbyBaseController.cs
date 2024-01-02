using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBaseController : MonoBehaviour
{
    protected NetworkRunnerController networkRunnerController;

    protected virtual void Awake()
    {
       // if (GlobalManagers.Instance != null)
            networkRunnerController = GlobalManagers.Instance.NetworkRunnerController;

    }
}
