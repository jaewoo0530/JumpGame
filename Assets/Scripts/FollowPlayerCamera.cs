using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player; // 따라갈 플레이어의 Transform
    public Vector3 offset; // 카메라와 플레이어 사이의 거리
    public float smoothSpeed = 0.125f; // 부드러운 이동 속도
    public Vector2 minBounds; // 카메라가 이동 가능한 최소값
    public Vector2 maxBounds; // 카메라가 이동 가능한 최대값

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 이동 범위 제한
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

        transform.position = smoothedPosition;
    }
}
