using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameUI gameUI;
    public HudUI hudUI;

    [HideInInspector] public GameFSM gameFSM = new GameFSM();

    private void Awake()
    {
        
    }

    private void Start()
    {
        gameFSM.Initialize(Callback_ReadyEnter, Callback_GameEnter, Callback_ResultEnter, Callback_EscEnter);
        GameMng.Ins.SetGameScene(this);

        gameFSM.SetReadyState();
    }

    private void Update()
    {
        if (gameFSM != null)
        {
            gameFSM.OnUpdate();
        }
    }

    private void Callback_ReadyEnter()
    {
        Debug.Log("Ready");

        gameUI.Init_Ready();
    }

    private void Callback_GameEnter()
    {
        Debug.Log("Game");
    }

    private void Callback_ResultEnter()
    {
        Debug.Log("Result");
    }

    private void Callback_EscEnter()
    {
        Debug.Log("ESC");
    }
}
