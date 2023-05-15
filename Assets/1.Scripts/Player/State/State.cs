using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Animator animator;
    void Start()
    {

    }
    public abstract void Action();
}
