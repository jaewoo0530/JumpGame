using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ üũ����Ʈ�� ����ߴ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // GameManager�� respawnPoint�� ���� üũ����Ʈ ��ġ�� ����
            GameManager.Instance.respawnPoint = transform;
            Debug.Log("Checkpoint Updated to: " + transform.position);
        }
    }
}
