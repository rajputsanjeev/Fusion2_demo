using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : BaseLobbyManagerPanel , IJoinRandomRoomPanel
{
    private IJoinRandomRoomController joinRandomRoomController;

    [Header("MiddleSectionPanel Vars")] 
    [SerializeField] private Button joinRandomRoomBtn;

    public void Init(IJoinRandomRoomController joinRandomRoomController)
    {
        this.joinRandomRoomController = joinRandomRoomController;
    }

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        joinRandomRoomBtn.onClick.AddListener(joinRandomRoomController.JoinRandomRoom);
    }
}