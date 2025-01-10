using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemoreJump : MonoBehaviour, IItem
{
    private PlayerController player;


    public void Use()
    {
        player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.JumpCount += 1;
        }
        Debug.Log("���� ���� ����");
        Destroy(gameObject);
    }

}

