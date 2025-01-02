using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // �ٴ����� �ν��� ���̾�
    public float rayLength = 0.2f; // ������ ����

    private bool isGrounded;

    void Update()
    {
        // ����ĳ��Ʈ ����
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        // ����׿� ���� ǥ��
        Debug.DrawRay(transform.position, Vector2.down * rayLength, isGrounded ? Color.green : Color.red);

        if (isGrounded)
        {
            Debug.Log("ĳ���ʹ� �ٴڿ� ��� �ֽ��ϴ�.");
        }
        else
        {
            Debug.Log("ĳ���ʹ� ���߿� �ֽ��ϴ�.");
        }
    }
}
