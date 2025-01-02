using UnityEngine;

public class SawSwing : MonoBehaviour
{
    public Transform centerPoint; // 흔들림 중심점
    public float radius = 2.0f;   // 흔들림 반지름
    public float swingSpeed = 2.0f; // 흔들림 속도 (진동 주기)

    private float currentTime = 0.0f; // 시간 누적

    void Update()
    {
        // 시간에 따라 좌우로 흔들리는 각도 계산
        currentTime += Time.deltaTime;
        float angle = Mathf.Sin(currentTime * swingSpeed) * 45.0f; // 최대 45도 각도로 좌우 흔들림

        // 새로운 위치 계산
        float x = centerPoint.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        // 물체 위치 업데이트
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
