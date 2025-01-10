using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private CheckPoint checkPoint;
    private CheckPoint previousCheckpoint;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        checkPoint = FindAnyObjectByType<CheckPoint>();
    }
    public void RespawnPlayer()
    {
        // ���ο� �÷��̾� �ν��Ͻ� ����
        GameManager.Instance.RespawnPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadObject"))
        {
            playerAnimator.SetTrigger("Die");
        }
        else if (other.TryGetComponent<IItem>(out var item))
        {
            item.Use();
        }
        else if (other.CompareTag("RespawnPoint"))
        {
            // ���� üũ����Ʈ ��Ȱ��ȭ
            if (previousCheckpoint != null)
            {
                previousCheckpoint.Deactivate();
            }

            // ���ο� üũ����Ʈ Ȱ��ȭ
            checkPoint.Save();

            // ���� üũ����Ʈ ������Ʈ
            previousCheckpoint = checkPoint;

            // ���ο� üũ����Ʈ�� ã��
            checkPoint = other.GetComponent<CheckPoint>();
        }
    }
    public void Die()
    {
        // ���� �÷��̾� �ı�
        Destroy(gameObject);

        // ������ ó��
        RespawnPlayer();
    }
}
