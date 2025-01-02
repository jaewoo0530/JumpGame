using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // 바닥으로 인식할 레이어
    public float rayLength = 0.2f; // 레이의 길이

    private bool isGrounded;

    void Update()
    {
        // 레이캐스트 실행
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        // 디버그용 레이 표시
        Debug.DrawRay(transform.position, Vector2.down * rayLength, isGrounded ? Color.green : Color.red);

        if (isGrounded)
        {
            Debug.Log("캐릭터는 바닥에 닿아 있습니다.");
        }
        else
        {
            Debug.Log("캐릭터는 공중에 있습니다.");
        }
    }
}
