using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISessionList
{
    void JoinSessiom(string feildName);
    void Init(ISessionListController sessionListController);
    void PhotonListnerData<T>(T data);
}
