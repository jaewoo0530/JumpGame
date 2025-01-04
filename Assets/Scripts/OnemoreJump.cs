using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnemoreJump : MonoBehaviour, IItem
{
    public void Use(GameObject target)
    {
        Debug.Log("점프 횟수 증가");
        Destroy(gameObject);
    }
}

