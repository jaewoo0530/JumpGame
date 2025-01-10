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
    private Player player;
    private GroundCheck groundCheck;

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
        groundCheck = GetComponent<GroundCheck>();
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
            if (groundCheck.IsGrounded)
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

        if (playerRigidbody2D.velocity.y < 0 && !groundCheck.IsGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && playerRigidbody2D.velocity.y > 0)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
        }

        if(groundCheck.IsGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", false);
        }
    }

    private void PerformJump()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
    }
}
