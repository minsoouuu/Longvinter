using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public enum State
    {
        None,
        Idle,
        Walk,
        Run,
        Attack,
        Die
    }

    [SerializeField] private State state = State.None;
    [SerializeField] private Animator animator;

    float speed = 3f;

    void Start()
    {
        
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    void FixedUpdate()
    {
        if (state.Equals(State.Die)) return;

        Move();
        Direction();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(x, 0, z);
        transform.position += vec * Speed * Time.deltaTime;

        SetAnimation(state);
    }

    void Direction()
    {
        float yDir = transform.rotation.y;
    }

    void SetAnimation(State state)
    {
        animator.SetTrigger(state.ToString());
    }
}
