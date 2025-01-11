using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform playerTransform; // 플레이어 Transform
    public Vector3 offset; // 카메라와 플레이어 사이의 거리
    public float smoothSpeed = 0.125f; // 부드러운 이동 속도

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
        Debug.Log("Player Transform registered by player!");
    }

    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            return; // 플레이어가 없으면 업데이트 중단
        }

        Vector3 desiredPosition = new Vector3(
            playerTransform.position.x + offset.x,
            playerTransform.position.y + offset.y,
            transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
