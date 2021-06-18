using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    Transform target;
    float maxDistance;
    float minDistance;
    float JumpDistance;

    Rigidbody2D rigid2D;
    float moveSpeed = 2;

    SpriteRenderer spriteRednerer;

    bool isJump;
    float jumpForce;


    private void Update()
    {
        Enemy_Move();
        Delay_Update();
    }

    public virtual void Init_Ready(Transform _target)
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRednerer = GetComponentInChildren<SpriteRenderer>();

        target = _target;

        maxDistance = 7;
        minDistance = 0.5f;
        JumpDistance = 3;

        moveSpeed = 2;

        SetIsJump(true);
        jumpForce = 6;

        Init_Delay();
    }

    private void Init_Delay()
    {
    }
    
    private bool CheckTargetPos()
    {
        if (GetDistance() <= maxDistance) return true;
        else return false;
    }

    private float GetDistance()
    {
        return Vector2.Distance(target.position, transform.position);
    }

    private bool CheckInDistance()
    {
        if (GetDistance() <= JumpDistance && target.position.y > transform.position.y + 1) 
            return true;
        else return false;
    }

    private void Delay_Update()
    {
    }

    private void Enemy_Move()
    {
        if (target == null) return;

        if (CheckTargetPos())
        {
            if (target.position.x > transform.position.x)
            {
                rigid2D.AddForce(Vector2.right * moveSpeed);
                SetFlipX(true);
            }
            else if (target.position.x < transform.position.x)
            {
                rigid2D.AddForce(Vector2.left * moveSpeed);
                SetFlipX(false);
            }
        }
        else
        {
        }

        Enemy_Jump();
    }

    private void Enemy_Jump()
    {
        if (!isJump) return;
        if (!CheckInDistance()) return;

        SetIsJump(false);
        rigid2D.velocity = new Vector2(0, jumpForce);
    }

    private void SetFlipX(bool bFlip)
    { spriteRednerer.flipX = bFlip; }

    private void SetIsJump(bool bJump)
    { isJump = bJump; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "EndPlatform")
        {
            SetIsJump(true);
            Debug.Log("충돌 시작");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "EndPlatform")
        {
            SetIsJump(true);
            Debug.Log("충돌 취소");
        }
    }
}
