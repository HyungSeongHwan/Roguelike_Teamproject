using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMng : MonoBehaviour
{
    const float rayDistance = 3;

    PlayerController player;
    [SerializeField] Transform EndPlatform;

    float tempPosY;

    private void Update()
    {
        Follow_Player();
    }

    public void Initialize(PlayerController _player)
    {
        player = _player;
    }

    private void Follow_Player()
    {
        if (player == null) return;

        Vector3 tempPos = Vector3.zero;
        tempPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        //일단 나중에 하자
        //if (!CloseDistance()) tempPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        //else
        //{
        //    tempPos = new Vector3(player.transform.position.x, transform.position.y, -10);
        //}

        transform.position = tempPos;
    }

    private bool CloseDistance()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player"));
        layerMask = ~layerMask;

        Ray2D ray = new Ray2D(transform.position, Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayDistance, layerMask);
        if (hit)
        {
            if (hit.collider.tag == "EndPlatform") return true;
        }

        return false;
    }
}
