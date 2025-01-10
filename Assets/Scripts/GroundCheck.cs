using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // �ٴ����� �ν��� ���̾�
    public float rayLength = 0.2f; // ������ ����

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        // ����ĳ��Ʈ ����
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        // ����׿� ���� ǥ��
        Debug.DrawRay(transform.position, Vector2.down * rayLength, IsGrounded ? Color.green : Color.red);
    }
}
