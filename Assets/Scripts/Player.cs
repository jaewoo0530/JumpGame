using UnityEngine;

public class Player : MonoBehaviour
{
    public void RespawnPlayer()
    {
        // ���ο� �÷��̾� �ν��Ͻ� ����
        GameManager.Instance.RespawnPlayer();
    }

    public void Die()
    {
        // ���� �÷��̾� �ı�
        Destroy(gameObject);

        // ������ ó��
        RespawnPlayer();
    }
}
