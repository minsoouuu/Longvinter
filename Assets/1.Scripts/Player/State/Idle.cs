using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Action()
    {
        if (animator == null)
        {
            animator = transform.parent.GetComponent<Animator>();
        }
        animator.SetTrigger("Idle");
    }
}
