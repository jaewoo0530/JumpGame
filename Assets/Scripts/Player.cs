using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private CheckPoint checkPoint;

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
            checkPoint.Save();
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
