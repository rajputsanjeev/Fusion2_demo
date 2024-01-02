using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPanelBase Vars")]
    public LobbyPanelType PanelType { get; private set; }
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private GameObject panelTransform;
    
    protected LobbyUIManager lobbyUIManager;
    
    public enum LobbyPanelType
    {
        None,
        CreateNicknamePanel,
        CreateOpenRoomPanel,
        CreatePrivateRoomPanel,
        JoinRandomRoompanel,
        JoinRoomWithNamePanel,
        MiddleSectionPanel,
        SessionListPanel
    }

    public virtual void InitPanel(LobbyUIManager uiManager)
    {
        lobbyUIManager = uiManager;
    }

    public void ShowPanel()
    {
        this.panelTransform.SetActive(true);
        const string POP_IN_CLIP_NAME = "In";
        //CallAnimationCoroutine(POP_IN_CLIP_NAME, true);
    }

    public void ClosePanel()
    {
        this.panelTransform.SetActive(false);
        const string POP_OUT_CLIP_NAME = "Out";
        //CallAnimationCoroutine(POP_OUT_CLIP_NAME, false);
    }

    private void CallAnimationCoroutine(string clipName, bool state)
    {
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, panelAnimator, clipName, state));
    }
}
