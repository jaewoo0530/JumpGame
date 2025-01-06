using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 3f;   // 최대 속도
    public float jumpForce = 4f;
    private float jumpCount = 0f;

    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;
    private bool isGrounded;
    private Player player;

    public float JumpCount
    {
        get => jumpCount; // 점프 횟수 가져오기
        set
        {
            jumpCount = Mathf.Max(0, value); // 음수 방지
            Debug.Log($"점프 횟수가 설정되었습니다: 현재 점프 횟수 = {jumpCount}");
        }
    }

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(xInput * speed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = move;

        playerAnimator.SetBool("Run", xInput != 0);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                PerformJump();
                playerAnimator.SetBool("Jump", true);
            }
            else if (jumpCount > 0)
            {
                PerformJump();
                playerAnimator.SetBool("DoubleJump", true);
                JumpCount -= 1;
            }
        }

        if (playerRigidbody2D.velocity.y < 0 && !isGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && playerRigidbody2D.velocity.y > 0)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
        }
    }

    private void PerformJump()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f && collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnimator.SetBool("Fall", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadObject"))
        {
            playerAnimator.SetTrigger("Die");
        }
        else if (other.TryGetComponent<IItem>(out var item))
        {
            item.Use();
        }
    }
}
