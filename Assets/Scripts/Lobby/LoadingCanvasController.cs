using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button cancelButton;

    private NetworkRunnerController networkRunnerController;
    void Start()
    {
        networkRunnerController = GlobalManager.Instance.networkRunnerController;
        networkRunnerController.OnStartedRunnerConnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSucessfully += OnPlayerJoinedSucessfully;

        cancelButton.onClick.AddListener(networkRunnerController.ShutDownRunner);

        this.gameObject.SetActive(false);
    }

    private void CancelRequest()
    {
        
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimationAndSetStateWhenFinished(gameObject, animator, CLIP_NAME));
    }

    private void OnPlayerJoinedSucessfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimationAndSetStateWhenFinished(gameObject, animator, CLIP_NAME, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnerConnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSucessfully -= OnPlayerJoinedSucessfully;
    }
}
