using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : NetworkBehaviour, IPlayerJoined
{
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab = NetworkPrefabRef.Empty;
    [SerializeField] private Transform[] spawnPoints;


    private void SpawnPlayer(PlayerRef playerRef)
    {
        if(Runner.IsServer)
        {
            Runner.Spawn(playerNetworkPrefab, Vector3.zero, Quaternion.identity, playerRef);
        }
    }
    public void PlayerJoined(PlayerRef player)
    {
        SpawnPlayer(player);
    }

}
