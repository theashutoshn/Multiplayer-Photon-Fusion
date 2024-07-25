using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private LobbyPanelBase[] lobbyPanels;
    void Start()
    {
        foreach(var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        foreach(var lobby in lobbyPanels)
        {
            if(lobby.Paneltype == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
