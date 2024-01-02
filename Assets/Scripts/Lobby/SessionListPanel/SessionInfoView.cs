using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;

public class SessionInfoView : MonoBehaviour
{
    [SerializeField]private string roomKey;

    private ISessionList sessionList;
    private SessionInfo sessionInfo;
    public Button joinSession;
    [SerializeField] private TMP_InputField roomCodeInputField;
    public TextMeshProUGUI sessionName;
    public TextMeshProUGUI playerJoinedSession;
    public TextMeshProUGUI maxPlayerJoinSession;

    public void SessionInfo(SessionInfo sessionInfo , ISessionList sessionList)
    {
        this.sessionInfo = sessionInfo;
        this.sessionList = sessionList;
        sessionName.text = sessionInfo.Name;
        playerJoinedSession.text = sessionInfo.PlayerCount.ToString();
        maxPlayerJoinSession.text = sessionInfo.MaxPlayers.ToString();

        joinSession.gameObject.SetActive(sessionInfo.IsOpen && sessionInfo.PlayerCount < sessionInfo.MaxPlayers);

        SessionProperty keyProperty;
        sessionInfo.Properties.TryGetValue("key", out keyProperty);

        roomKey = string.Empty;

        if (keyProperty == null)
        {
            roomKey = string.Empty;
        }
        else
        {
            roomKey = keyProperty.PropertyValue as string;
        }
        Debug.Log("Key " + roomKey);
        roomCodeInputField.gameObject.SetActive(roomKey != string.Empty);

        joinSession.onClick.AddListener(JoinSession);
    }

    public void OnDestroy()
    {
        joinSession.onClick.RemoveAllListeners();
    }

    private void JoinSession()
    {
        if(roomKey == "")
          sessionList.JoinSessiom(sessionInfo.Name);
        else
        {
            if(roomKey == roomCodeInputField.text)
            {
                sessionList.JoinSessiom(sessionInfo.Name);
            }
            else
            {
                Debug.Log("Room Code is Not Equal");
            }
        }
    }
}
