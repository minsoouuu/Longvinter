using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    public override void Action()
    {
        animator.SetTrigger("Run");
    }
}
