using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Animator endAnimator;
    private void Awake()
    {
        endAnimator = GetComponent<Animator>();
    }

    public void EndPressed()
    {
        endAnimator.SetBool("Pressed", true);
        Debug.Log("End stage");
    }
}
