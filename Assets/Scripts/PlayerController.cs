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
            // 벽 방향으로 입력이 들어왔을 때 수평 이동 제거
            move.x = 0;
        }

        playerRigidbody2D.velocity = move;

        playerAnimator.SetBool("Run", Mathf.Abs(xInput) > 0.01f);
    }

    private bool IsTouchingWall()
    {
        float direction = Input.GetAxis("Horizontal");
        if (Mathf.Approximately(direction, 0))
            return false; // 입력이 없으면 감지 중단

        Vector2 rayOrigin = (Vector2)transform.position + new Vector2(direction * 0.5f, 0); // 캐릭터의 좌우 가장자리
        float wallCheckDistance = 0.2f; // 레이 길이
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * Mathf.Sign(direction), wallCheckDistance, LayerMask.GetMask("Wall"));

        return hit.collider != null;
    }


    private void HandleJump()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // PC에서 Space 키로 점프
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
    // 모바일에서 터치로 점프
    if (IsTouchJump())
    {
        HandleJumpLogic();
    }

    if (IsTouchReleased() && playerRigidbody2D.velocity.y > 0)
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y * 0.5f);
    }
#endif

        // 공통: 낙하 애니메이션 처리
        if (playerRigidbody2D.velocity.y < 0 && !groundCheck.IsGrounded)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("DoubleJump", false);
            playerAnimator.SetBool("Fall", true);
        }

        // 공통: 착지 시 애니메이션 초기화
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
        // 화면을 터치했는지 확인
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
        // 화면에서 터치가 떼어진 경우 확인
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
