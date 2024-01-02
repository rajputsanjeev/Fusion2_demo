using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoomWithNamePanel : BaseLobbyManagerPanel, IJoinRoomWithNamePanel
{
    private IJoinRoomWithNameController joinRoomWithNameController;

    [SerializeField] private Button joinRoomBtn;
    [SerializeField] private TMP_InputField joinRoomNameInputField;

    public void Init(IJoinRoomWithNameController joinRoomWithNameController)
    {
        this.joinRoomWithNameController = joinRoomWithNameController;
    }
    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        joinRoomBtn.onClick.AddListener(() => JoinRoomWithName(GameMode.Client, joinRoomNameInputField.text));
    }

    private void JoinRoomWithName(GameMode mode, string field)
    {
        if (field.Length >= 2)
        {
            Debug.Log($"------------{mode}------------");
            joinRoomWithNameController.JoinRoomWithName(mode, field);
        }
    }

}
