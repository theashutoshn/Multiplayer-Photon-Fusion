using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }

    [field: SerializeField] public NetworkRunnerController networkRunnerController { get; private set; }

    [SerializeField] private GameObject dontDestroyOnLoadParentObj;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(dontDestroyOnLoadParentObj.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
