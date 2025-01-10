using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // 바닥으로 인식할 레이어
    public float rayLength = 0.2f; // 레이의 길이

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        // 레이캐스트 실행
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        // 디버그용 레이 표시
        Debug.DrawRay(transform.position, Vector2.down * rayLength, IsGrounded ? Color.green : Color.red);
    }
}
