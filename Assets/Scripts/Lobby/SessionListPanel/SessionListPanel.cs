using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionListPanel : LobbyPanelBase , ISessionList                                                                                                                                               
{
    private ISessionListController sessionListController;

    [SerializeField] private Button createOpenRoomBtn;
    [SerializeField] private Button createPrivateRoomBtn;
    [SerializeField] private Button joinRandomRoomBtn;
    [SerializeField] private Button joinRoomWithNameBtn;
    [SerializeField] private RectTransform publicSessionConatiner;
    [SerializeField] private RectTransform privateSessionConatiner;
    [SerializeField] private SessionInfoView sessionInfoView;

    public void Init(ISessionListController sessionListController)
    {
        this.sessionListController = sessionListController;
    }

    public override void InitPanel(LobbyUIManager lobbyUIManager)
    {
        base.InitPanel(lobbyUIManager);
        createOpenRoomBtn.onClick.AddListener(OnClickCreateOpenRoom);
        createPrivateRoomBtn.onClick.AddListener(OnClickCreatePrivateRoom);
        joinRandomRoomBtn.onClick.AddListener(OnClickJoinRandomRoom);
        joinRoomWithNameBtn.onClick.AddListener(OnClickJoinRoomWithName);
    }

    public void PhotonListnerData<T>(T data)
    {
        Debug.Log("PhotonListnerData Recieved");

        if(data.GetType() == typeof(List<SessionInfo>))
        {
            Debug.Log("Type Same ");

            List<SessionInfo> sessionInfos = data as List<SessionInfo>;

            foreach (var session in sessionInfos)
            {
                SessionProperty keyProperty;
                session.Properties.TryGetValue("key", out keyProperty);

                string key = "";    

                if(keyProperty == null)
                {
                    key = string.Empty;
                }else
                {
                    key = keyProperty.ToString();
                }

                if (key == null || key == ""|| key == string.Empty)
                {
                    SessionInfoView sessionInfo = Instantiate(sessionInfoView, publicSessionConatiner);
                    sessionInfo.SessionInfo(session, this);
                }
                else
                {
                    SessionInfoView sessionInfo = Instantiate(sessionInfoView, privateSessionConatiner);
                    sessionInfo.SessionInfo(session, this);
                }
            }
        }
    }

    public void JoinSessiom(string feildName)
    {
        sessionListController.JoinSessiom(feildName);
    }

    private void OnClickCreateOpenRoom()
    {
        lobbyUIManager.ShowPanel(LobbyPanelType.CreateOpenRoomPanel);
    }

    private void OnClickCreatePrivateRoom()
    {
        lobbyUIManager.ShowPanel(LobbyPanelType.CreatePrivateRoomPanel);
    }

    private void OnClickJoinRandomRoom()
    {
        lobbyUIManager.ShowPanel(LobbyPanelType.JoinRandomRoompanel);
    }

    private void OnClickJoinRoomWithName()
    {
        lobbyUIManager.ShowPanel(LobbyPanelType.JoinRoomWithNamePanel);
    }
}
