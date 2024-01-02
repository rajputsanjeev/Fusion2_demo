using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateOpenRoomPanel : BaseLobbyManagerPanel , ICreateOpenRoomPanel
{
    private ICreateOpenRoomController createOpenRoomController;

    [SerializeField] private Button createOpenRoomBtn;
    [SerializeField] private TMP_InputField createRoomInputField;

    public void Init(ICreateOpenRoomController createOpenRoomController)
    {
        this.createOpenRoomController = createOpenRoomController;
    }

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        createOpenRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputField.text));
    }

    private void CreateRoom(GameMode mode, string field)
    {
        if (field.Length >= 2)
        {
            Debug.Log($"------------{mode}------------");
            createOpenRoomController.CreateRoom(mode, field);
        }
    }
}
