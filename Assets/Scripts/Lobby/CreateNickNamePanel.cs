using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateNickNamePanel : LobbyPanelBase
{
    [Header("CreateNickNamePanel Vars")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button createNickNameButton;
    private const int inputchar= 2;
    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);
    
        createNickNameButton.interactable = false; // dont want to make button active unless name is typed
        createNickNameButton.onClick.AddListener(OnClickCreateNickname);
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    void OnInputFieldValueChanged(string value)
    {
        createNickNameButton.interactable = value.Length >= inputchar;
    }

    void OnClickCreateNickname()
    {
        var nickName = inputField.text;
        if(nickName.Length >= inputchar)
        {
            base.ClosePanel(); //close current panel
            lobbyUIManager.ShowPanel(LobbyPanelType.MiddleSectionPanel); //show next panel
        }
    }
}
