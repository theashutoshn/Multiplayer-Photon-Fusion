using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab = NetworkPrefabRef.Empty;
    [SerializeField] private Transform[] spawnPoints;

    public override void Spawned()
    {
        if(Runner.IsServer)
        {
            foreach(var item in Runner.ActivePlayers)
            {
                SpawnPlayer(item);
            }
        }
    }
    private void SpawnPlayer(PlayerRef playerRef)
    {
        if(Runner.IsServer)
        {
            var index = playerRef % spawnPoints.Length;
            var spawnPoint = spawnPoints[index].transform.position;
            var playerObj = Runner.Spawn(playerNetworkPrefab, spawnPoint, Quaternion.identity, playerRef);

            Runner.SetPlayerObject(playerRef, playerObj);
        }
    }

    private void DespawnPlayer(PlayerRef playerRef)
    {
        if(Runner.IsServer)
        {
            if(Runner.TryGetPlayerObject(playerRef, out var playerNetworkObj))
            {
                Runner.Despawn(playerNetworkObj);
            }

            Runner.SetPlayerObject(playerRef, null);
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        SpawnPlayer(player);
    }

    public void PlayerLeft(PlayerRef player)
    {
        DespawnPlayer(player);
    }
}
