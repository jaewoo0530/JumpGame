using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private CheckPoint previousCheckpoint; // 이전 체크포인트 추적

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
            // 현재 부딪힌 체크포인트 가져오기
            CheckPoint currentCheckpoint = other.GetComponent<CheckPoint>();

            if (currentCheckpoint != null)
            {
                // 이전 체크포인트 비활성화
                if (previousCheckpoint != null && previousCheckpoint != currentCheckpoint)
                {
                    previousCheckpoint.Deactivate();
                }

                // 현재 체크포인트 활성화
                currentCheckpoint.Save();

                // 이전 체크포인트 업데이트
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
        // 현재 플레이어 파괴
        Destroy(gameObject);

        // 리스폰 처리
        RespawnPlayer();
    }
}
