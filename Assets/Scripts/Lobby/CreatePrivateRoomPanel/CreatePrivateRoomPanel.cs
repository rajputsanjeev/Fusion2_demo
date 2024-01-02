using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatePrivateRoomPanel : BaseLobbyManagerPanel, ICreatePrivateRoomPanel
{
    private ICreatePrivateRoomController createPrivateRoomController;

    [SerializeField] private Button createPrivateRoomBtn;
    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TMP_InputField roomKeyInputField;

    public void Init(ICreatePrivateRoomController createPrivateRoomController)
    {
        this.createPrivateRoomController = createPrivateRoomController;
    }

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        createPrivateRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, roomNameInputField.text, roomKeyInputField.text));
    }

    private void CreateRoom(GameMode mode, string field, string key)
    {
        if (field.Length >= 2)
        {
            Debug.Log($"------------{mode}------------");
            createPrivateRoomController.CreateRoom(mode, field, key);
        }
    }

}
