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
        // 체크포인트 비활성화 애니메이션
        checkpointAnimator.SetBool("Idle", false);
        checkpointAnimator.SetBool("Activate", false);
        checkpointAnimator.SetBool("Deactivate", true); // 비활성화 애니메이션
    }
}
