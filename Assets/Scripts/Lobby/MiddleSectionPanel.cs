using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : LobbyPanelBase
{

    [Header("MiddleSectionPanel vars")]
    [SerializeField] private Button joinRandomRoomButton;
    [SerializeField] private Button joinRoomByArgButton;
    [SerializeField] private Button createRoomButton;

    [SerializeField] private TMP_InputField joinRoomByArgInputField;
    [SerializeField] private TMP_InputField createRoomInputField;

    private NetworkRunnerController networkRunnerController;
    // instead of using Start(), But why bC
    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        networkRunnerController = GlobalManager.Instance.networkRunnerController;
        joinRandomRoomButton.onClick.AddListener(JoinRandomRoom);
        joinRoomByArgButton.onClick.AddListener(JoinRoomByArg);
        createRoomButton.onClick.AddListener(CreateRoom);

    }
    private void CreateRoom()
    {
        if(createRoomInputField.text.Length >= 2)
        {
            Debug.Log($"----------Create Room---------");
            GlobalManager.Instance.networkRunnerController.StartGame(GameMode.Host, createRoomInputField.text);
            // or 
            //networkRunnerController.StartGame(GameMode.Host, createRoomInputField.text);
        }
    }
    private void JoinRoomByArg()
    {
        if (joinRoomByArgInputField.text.Length >= 2)
        {
            Debug.Log($"----------Join Room By Args---------");
            GlobalManager.Instance.networkRunnerController.StartGame(GameMode.Client, joinRoomByArgInputField.text);
            // or 
            //networkRunnerController.StartGame(GameMode.Client, joinRoomByArgInputField.text);
        }
    }

    // this will either create a room or join a room, if text is written and if room doesnt find then its a host and if room is found then its client
    private void JoinRandomRoom()
    {
        Debug.Log($"----------Join Random Room---------");
        GlobalManager.Instance.networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
        // or 
        //networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
    }

}
