using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private CheckPoint checkPoint;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    public void RespawnPlayer()
    {
        // 새로운 플레이어 인스턴스 생성
        GameManager.Instance.RespawnPlayer();
        checkPoint = FindAnyObjectByType<CheckPoint>();
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
        // 현재 플레이어 파괴
        Destroy(gameObject);

        // 리스폰 처리
        RespawnPlayer();
    }
}
