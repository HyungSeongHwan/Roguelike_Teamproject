using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng
{
    static GameMng ins = null;
    public static GameMng Ins
    {
        get
        {
            if (ins == null) ins = new GameMng();
            return ins;
        }
    }

    public GameScene gameScene;

    public float DurationTime;

    public void Initialize()
    {
        Application.runInBackground = true;
        DurationTime = 0.0f;
    }

    public void OnUpdate(float elapsedTime)
    {
        DurationTime += elapsedTime;
    }

    public void SetGameScene(GameScene _gameScene) { gameScene = _gameScene; }
    public GameScene GetGameScene() { return gameScene; }
}
