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
        // �÷��̾ üũ����Ʈ�� ����ߴ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // GameManager�� respawnPoint�� ���� üũ����Ʈ ��ġ�� ����
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
