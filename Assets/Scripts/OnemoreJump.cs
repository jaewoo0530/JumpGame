using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemoreJump : MonoBehaviour, IItem
{
    public void Use(GameObject target)
    {
        Debug.Log("���� Ƚ�� ����");
        Destroy(gameObject);
    }
}

