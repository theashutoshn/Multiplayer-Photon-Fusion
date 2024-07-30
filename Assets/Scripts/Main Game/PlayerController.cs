using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 6;

    private float horizontal;
    private Rigidbody2D rb2d;  // Changed to Rigidbody2D

    public override void Spawned()
    {
        rb2d = GetComponent<Rigidbody2D>();  // Changed to Rigidbody2D
    }

    public void Update()
    {
        BeforeUpdate();
    }
    public void BeforeUpdate()
    {
        if (Object.HasInputAuthority)  // Corrected input authority check
        {
            horizontal = Input.GetAxis("Horizontal");
            Debug.Log("Horizontal Input: " + horizontal);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (Runner.TryGetInputForPlayer<PlayerData>(Object.InputAuthority, out var input)) 
        {
            Debug.Log("Input Retrieved: " + input.HorizontalInput);
            rb2d.velocity = new Vector2(input.HorizontalInput * moveSpeed, rb2d.velocity.y);
        }
    }

    public PlayerData GetPlayerNetworkInput()
    {
        PlayerData data = new PlayerData();
        data.HorizontalInput = horizontal;
        return data;
    }
}
