using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class SessionListController : PhotonListener<List<SessionInfo>>, ISessionListController
{
    private ISessionList sessionList;

    private NetworkRunnerController networkRunnerController;

    protected override void Awake()
    {
        base.Awake();

        if (GlobalManagers.Instance != null)
            networkRunnerController = GlobalManagers.Instance.NetworkRunnerController;

        sessionList = GetComponent<ISessionList>();
        sessionList.Init(this);
    }

    public override void OnPhotonEventExecuted(List<SessionInfo> data)
    {
        Debug.Log("Session List " +data.Count);
        sessionList.PhotonListnerData(data);
    }

    public void JoinSessiom(string feildName)
    {
        networkRunnerController.StartGame(GameMode.Client, feildName);
    }
}
