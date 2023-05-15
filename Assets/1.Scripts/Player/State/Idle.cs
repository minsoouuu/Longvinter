using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Action()
    {
        if (animator == null)
            return;
        animator.SetTrigger("Idle");
    }
}
