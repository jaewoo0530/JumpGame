using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private CheckPoint previousCheckpoint; // ���� üũ����Ʈ ����

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        FollowPlayerCamera cameraScript = FindObjectOfType<FollowPlayerCamera>();
        if (cameraScript != null)
        {
            cameraScript.SetPlayerTransform(transform);
        }
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
            // ���� �ε��� üũ����Ʈ ��������
            CheckPoint currentCheckpoint = other.GetComponent<CheckPoint>();

            if (currentCheckpoint != null)
            {
                // ���� üũ����Ʈ ��Ȱ��ȭ
                if (previousCheckpoint != null && previousCheckpoint != currentCheckpoint)
                {
                    previousCheckpoint.Deactivate();
                }

                // ���� üũ����Ʈ Ȱ��ȭ
                currentCheckpoint.Save();

                // ���� üũ����Ʈ ������Ʈ
                previousCheckpoint = currentCheckpoint;
            }
        }
        else if (other.CompareTag("End"))
        {
            End end = other.GetComponent<End>();

            if (end != null)
            {
                end.EndPressed();
            }
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
