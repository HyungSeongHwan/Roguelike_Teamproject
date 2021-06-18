using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] CameraMng cameraMng;
    [SerializeField] PlayerController player;
    [SerializeField] List<EnemyBase> Enemylist = new List<EnemyBase>();

    public void Init_Ready()
    {
        cameraMng.Initialize(player);
        player.Init_Ready();
        for (int i = 0; i < Enemylist.Count; ++i) Enemylist[i].Init_Ready(player.transform);
    }

    public void shorDistanceChekc()
    {

    }
}
