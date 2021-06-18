using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public void Initialize()
    {
        Show(false);
    }

    public void SetTarget()
    {
        GameUI gameUI = GameMng.Ins.gameScene.gameUI;

    }

    public void Show(bool bShow)
    {
        gameObject.SetActive(bShow);
    }
}
