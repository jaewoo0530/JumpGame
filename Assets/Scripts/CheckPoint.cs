using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator checkpointAnimator;

    private void Awake()
    {
        checkpointAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 체크포인트를 통과했는지 확인
        if (other.CompareTag("Player"))
        {
            // GameManager의 respawnPoint를 현재 체크포인트 위치로 갱신
            GameManager.Instance.respawnPoint = transform;
            Debug.Log("Checkpoint Updated to: " + transform.position);
            checkpointAnimator.SetBool("Activate", true);
        }
    }

    private void Idle()
    {
        checkpointAnimator.SetBool("Idle", true);
        checkpointAnimator.SetBool("Activate", false);
    }
}
