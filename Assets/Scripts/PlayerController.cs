using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 3f;   // �ִ� �ӵ�
    public float jumpForce = 4f;
    private float jumpCount = 0f;

    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;
    private GroundCheck groundCheck;

    public float JumpCount
    {
        get => jumpCount; // ���� Ƚ�� ��������
        set
        {
            jumpCount = Mathf.Max(0, value); // ���� ����
            Debug.Log($"���� Ƚ���� �����Ǿ����ϴ�: ���� ���� Ƚ�� = {jumpCount}");
        }
    }

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
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

        if (IsTouchingWall() && !groundCheck.IsGrounded && Mathf.Sign(xInput) == Mathf.Sign(playerRigidbody2D.velocity.x))
        {
            // �� �������� �Է��� ������ �� ���� �̵� ����
            move.x = 0;
        }

        playerRigidbody2D.velocity = move;

        playerAnimator.SetBool("Run", Mathf.Abs(xInput) > 0.01f);
    }

    private bool IsTouchingWall()
    {
        float direction = Input.GetAxis("Horizontal");
        if (Mathf.Approximately(direction, 0))
            return false; // �Է��� ������ ���� �ߴ�

        Vector2 rayOrigin = (Vector2)transform.position + new Vector2(direction * 0.5f, 0); // ĳ������ �¿� �����ڸ�
        float wallCheckDistance = 0.2f; // ���� ����
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * Mathf.Sign(direction), wallCheckDistance, LayerMask.GetMask("Wall"));

        return hit.collider != null;
    }


    private void HandleJump()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // PC���� Space Ű�� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJumpLogic();
        }

        if (Input.GetKeyUp(KeyCode.Space) && playerRigidbody2D.velocity.y > 0)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
        }
#endif

#if UNITY_IOS || UNITY_ANDROID
    // ����Ͽ��� ��ġ�� ����
    if (IsTouchJump())
    {
        HandleJumpLogic();
    }

    if (IsTouchReleased() && playerRigidbody2D.velocity.y > 0)
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
    }
#endif

        // ����: ���� �ִϸ��̼� ó��
        if (playerRigidbody2D.velocity.y < 0 && !groundCheck.IsGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", true);
        }

        // ����: ���� �� �ִϸ��̼� �ʱ�ȭ
        if (groundCheck.IsGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", false);
        }
    }

    private void HandleJumpLogic()
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
            jumpCount -= 1;
        }
    }

    private bool IsTouchJump()
    {
        // ȭ���� ��ġ�ߴ��� Ȯ��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsTouchReleased()
    {
        // ȭ�鿡�� ��ġ�� ������ ��� Ȯ��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                return true;
            }
        }
        return false;
    }


    private void PerformJump()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
    }
}
