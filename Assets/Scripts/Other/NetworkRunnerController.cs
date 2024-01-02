using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerController : NetworkRunnerControllerBase, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunnerInstance;

    protected override void Awake()
    {
        base.Awake();

        NetworkRunner networkRunnerSceneInstance = FindObjectOfType<NetworkRunner>();

        if (networkRunnerSceneInstance != null)
        {
            networkRunnerInstance = networkRunnerSceneInstance;
        }
    }

    private void Start()
    {
        if (networkRunnerInstance == null)
        {
            networkRunnerInstance = Instantiate(networkRunnerPrefab);
            networkRunnerInstance.name = "NetworkRunner";

            //Register so we will get the callbacks as well
            networkRunnerInstance.AddCallbacks(this);
        }
    }

    public override async Task JoinLobby()
    {
        _ = base.JoinLobby();

        if (networkRunnerInstance != null)
        {
            var result = await networkRunnerInstance.JoinSessionLobby(sessionLobby: SessionLobby.Custom, "customID");

            if (result != null)
            {
                if (result.Ok)
                {
                    Debug.Log("Connected To Lobby");
                }
            }
        }
    }

    public async void StartGame(GameMode mode, string roomName , Dictionary<string, SessionProperty> SessionProperties = null,bool isOpen = true, bool isVisible = true)
    {
        NetworkSceneInfo scene = new NetworkSceneInfo();
        scene.AddSceneRef(SceneRef.FromIndex(1));

        //ProvideInput means that that player is recording and sending inputs to the server.
        networkRunnerInstance.ProvideInput = true;

        var startGameArgs = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
            PlayerCount = 4,
            SessionProperties = SessionProperties,
            Scene = scene,
            IsOpen = isOpen,
            IsVisible = isVisible,
            SceneManager = networkRunnerInstance.GetComponent<INetworkSceneManager>()
        };

        await networkRunnerInstance.StartGame(startGameArgs);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerJoined");
        //{
        //    runner.SessionInfo.IsOpen = !(runner.SessionInfo.PlayerCount <= runner.SessionInfo.MaxPlayers);
        //    runner.SessionInfo.IsVisible = !(runner.SessionInfo.PlayerCount <= runner.SessionInfo.MaxPlayers);
        //}
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerLeft");
        //{
        //    runner.SessionInfo.IsOpen = !(runner.SessionInfo.PlayerCount <= runner.SessionInfo.MaxPlayers);
        //    runner.SessionInfo.IsVisible = !(runner.SessionInfo.PlayerCount <= runner.SessionInfo.MaxPlayers);
        //}
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Debug.Log("OnInput");
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("OnInputMissing");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("OnShutdown");
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("OnDisconnectedFromServer");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
        request.Accept();
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("OnConnectFailed "+ reason);
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("OnUserSimulationMessage");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("OnSessionListUpdated");
        CallPhotonListner(sessionList);
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("OnCustomAuthenticationResponse");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("OnHostMigration");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        Debug.Log("OnReliableDataReceived");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("OnSceneLoadDone");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("OnSceneLoadStart");
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        throw new NotImplementedException();
    }
}
