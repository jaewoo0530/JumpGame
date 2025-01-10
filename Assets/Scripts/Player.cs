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
        // 새로운 플레이어 인스턴스 생성
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
            // 기존 체크포인트 비활성화
            if (previousCheckpoint != null)
            {
                previousCheckpoint.Deactivate();
            }

            // 새로운 체크포인트 활성화
            checkPoint.Save();

            // 이전 체크포인트 업데이트
            previousCheckpoint = checkPoint;

            // 새로운 체크포인트를 찾음
            checkPoint = other.GetComponent<CheckPoint>();
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
