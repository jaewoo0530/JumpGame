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
            player.JumpCount += 1;
        }
        Debug.Log("���� ���� ����");
        Destroy(gameObject);
    }

}

