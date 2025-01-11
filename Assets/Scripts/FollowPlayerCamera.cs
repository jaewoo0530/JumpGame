using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player; // ���� �÷��̾��� Transform
    public Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ�
    public float smoothSpeed = 0.125f; // �ε巯�� �̵� �ӵ�
    public Vector2 minBounds; // ī�޶� �̵� ������ �ּҰ�
    public Vector2 maxBounds; // ī�޶� �̵� ������ �ִ밪

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // �̵� ���� ����
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

        transform.position = smoothedPosition;
    }
}
