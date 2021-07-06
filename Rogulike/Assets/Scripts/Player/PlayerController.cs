using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Player_Direction { Up, Down, Left, Right };
    public Player_Direction direction = Player_Direction.Left;
    Player_Direction tempDirection = Player_Direction.Left;

    Rigidbody2D rigid2D;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    float moveSpeed;
    bool isMove;

    float jumpForce;
    public bool isJump;

    float tickDown;
    float delayDown;

    bool isGetItem;
    ItemObj CollItem;

    private void Update()
    {
        Delay_Update();
        Player_Move();
        GainItem();
    }

    public void Init_Ready()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        moveSpeed = 5.0f;
        jumpForce = 6.0f;

        tickDown = 0;
        delayDown = 0.5f;

        SetIsMove(true);
        SetIsJump(true);
    }

    public void SetIsMove(bool bMove)
    { isMove = bMove; }

    public void SetIsJump(bool bJump)
    { isJump = bJump; }

    public void SetDirection(Player_Direction _direction)
    {
        if (direction == _direction) return;
        if (!isJump) return;

        direction = _direction;

        if (direction == Player_Direction.Right) spriteRenderer.flipX = false;
        else if (direction == Player_Direction.Left) spriteRenderer.flipX = true;

        // 나중에 애니메이션 추가
    }

    private void Player_Move()
    {
        if (!isMove) return;

        float xValue = Input.GetAxis("Horizontal");

        if (xValue > 0.0f) SetDirection(Player_Direction.Right);
        else if (xValue < 0.0f) SetDirection(Player_Direction.Left);

        transform.position += (transform.right * xValue * moveSpeed * Time.deltaTime);

        Player_Jump();
        Player_Down();
    }

    private void Player_Jump()
    {
        if (!isJump) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempDirection = direction;
            SetDirection(Player_Direction.Up);
            boxCollider.isTrigger = true;
            tickDown = 0;

            SetIsJump(false);
            rigid2D.velocity = new Vector2(0, jumpForce);
        }
    }

    private void Player_Down()
    {
        if (!isJump) return;
        if (!Input.GetKey(KeyCode.S)) return;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            boxCollider.isTrigger = true;
            tickDown = 0;
        }
    }

    private void Delay_Update()
    {
        if (boxCollider == null) return;

        tickDown += Time.deltaTime;
        if (tickDown >=delayDown)
        {
            boxCollider.isTrigger = false;
        }
    }

    private void GainItem()
    {
        if (!isGetItem) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ItemMng.Ins.GainNewItem(CollItem);
            CollItem.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            CollPlatForm();
        }
        else if (collision.gameObject.tag == "EndPlatform")
        {
            CollPlatForm();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            isGetItem = true;

            CollItem = collision.GetComponent<ItemObj>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            isGetItem = false;
        }
    }

    private void CollPlatForm()
    {
        SetDirection(tempDirection);
        SetIsJump(true);
    }
}
