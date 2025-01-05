using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemoreJump : MonoBehaviour, IItem
{
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Use()
    {
        if (player != null)
        {
            player.IncreaseJumpCount(0);
        }
        Debug.Log("점프 재사용 가능");
        Destroy(gameObject);
    }

}

