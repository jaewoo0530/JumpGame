using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator checkpointAnimator;

    private void Awake()
    {
        checkpointAnimator = GetComponent<Animator>();
    }

    public void Save()
    {
        checkpointAnimator.SetBool("Idle", false);
        checkpointAnimator.SetBool("Activate", true);
        checkpointAnimator.SetBool("Deactivate", false);
    }


    private void Idle()
    {
        checkpointAnimator.SetBool("Idle", true);
        checkpointAnimator.SetBool("Activate", false);
        checkpointAnimator.SetBool("Deactivate", false);
    }

    public void Deactivate()
    {
        // üũ����Ʈ ��Ȱ��ȭ �ִϸ��̼�
        checkpointAnimator.SetBool("Idle", false);
        checkpointAnimator.SetBool("Activate", false);
        checkpointAnimator.SetBool("Deactivate", true); // ��Ȱ��ȭ �ִϸ��̼�
    }
}
