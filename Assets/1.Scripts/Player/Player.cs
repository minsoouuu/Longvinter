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

    float maxHP = 100f;
    float speed = 3f;
    float curHP = 0f;
    float damage = 10f;

    public float HP
    {
        get { return curHP; }
        set
        { 
            curHP = value;
            // 죽을때 상태 처리
        }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float Damage
    {
        get { return damage; }
    }
    void Start()
    {
        curHP = maxHP;
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
        //asdasdasd
    }
}
