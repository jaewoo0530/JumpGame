using UnityEngine;

public class SawSwing : MonoBehaviour
{
    public Transform centerPoint; // ��鸲 �߽���
    public float radius = 2.0f;   // ��鸲 ������
    public float swingSpeed = 2.0f; // ��鸲 �ӵ� (���� �ֱ�)

    private float currentTime = 0.0f; // �ð� ����

    void Update()
    {
        // �ð��� ���� �¿�� ��鸮�� ���� ���
        currentTime += Time.deltaTime;
        float angle = Mathf.Sin(currentTime * swingSpeed) * 45.0f; // �ִ� 45�� ������ �¿� ��鸲

        // ���ο� ��ġ ���
        float x = centerPoint.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        // ��ü ��ġ ������Ʈ
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
