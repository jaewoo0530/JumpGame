using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾� Transform
    public Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ�
    public float smoothSpeed = 0.125f; // �ε巯�� �̵� �ӵ�

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
        Debug.Log("Player Transform registered by player!");
    }

    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            return; // �÷��̾ ������ ������Ʈ �ߴ�
        }

        Vector3 desiredPosition = new Vector3(
            playerTransform.position.x + offset.x,
            playerTransform.position.y + offset.y,
            transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
