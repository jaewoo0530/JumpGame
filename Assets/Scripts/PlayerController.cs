using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;   // �ִ� �ӵ�
    public float jumpForce = 4f;
    private Rigidbody2D playerRigidbody2D;
    private bool isGrounded;
    private Animator playeranimator;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playeranimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(xInput * speed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = move;
        if(xInput != 0)
        {
            playeranimator.SetBool("Run", true);
        }
        else
        {
            playeranimator.SetBool("Run", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ����: ���� ���� �ӵ��� �����ϰ�, ���� ���� y�࿡ ����
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
            playeranimator.SetBool("Jump", true);
        }
        else if (playerRigidbody2D.velocity.y < 0 && !isGrounded)
        {
            // ����: y �ӵ��� ������ ��, �� �Ʒ��� ������ ��
            playeranimator.SetBool("Jump", false);
            playeranimator.SetBool("Fall", true);
        }
        else if (isGrounded)
        {
            // ���� ���� �� Jump �ִϸ��̼��� false�� ����
            playeranimator.SetBool("Jump", false);
            playeranimator.SetBool("Fall", false);
        }
        if (Input.GetKeyUp(KeyCode.Space) && playerRigidbody2D.velocity.y > 0)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
