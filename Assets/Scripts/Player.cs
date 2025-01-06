using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab; // �÷��̾� ������
    public Transform respawnPoint;  // ������ ��ġ

    public void RespawnPlayer()
    {
        // ���ο� �÷��̾� �ν��Ͻ� ����
        Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
    }
    public void Die()
    {
        Destroy(gameObject);
        RespawnPlayer();
    }
}
