using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkRunnerControllerBase : MonoBehaviour
{
    public static NetworkRunnerControllerBase Instance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public virtual async Task JoinLobby()
    {
    }

    protected void CallPhotonListner<T>(T data)
    {
        PhotonListener<T>.Instance.OnPhotonEventExecuted(data);
    }
}
