using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemoreJump : MonoBehaviour, IItem
{
    public void Use()
    {
        Debug.Log("���� Ƚ�� ����");
        Destroy(gameObject);
    }
}

