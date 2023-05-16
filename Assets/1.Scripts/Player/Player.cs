using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MyState
{
    None,
    Idle,
    Walk,
    Run,
    Attack,
    Die
}
public abstract class Player : MonoBehaviour
{
    [SerializeField] private MyState myState = MyState.None;
    [SerializeField] private Animator animator;

    float x;
    float z;

    float maxHP = 100f;
    float speed = 3f;
    float curHP = 0f;
    float damage = 10f;
    float mentalPower = 0f;

    public float HP
    {
        get { return curHP; }
        set
        {
            curHP = value;
            if (curHP <= 0)
            {
                myState = MyState.Die;
            }
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
        set { Damage = value; }
    }
    public float MentalPower
    {
        get { return mentalPower; }
        set { mentalPower = value; }
    }
    void Start()
    {
        curHP = maxHP;
    }
    void FixedUpdate()
    {
        if (myState.Equals(MyState.Die)) return;
        Move();
    }
    void Update()
    {
        if (myState.Equals(MyState.Die)) return;
    }

    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (transform.position != Vector3.zero)
        {
            myState = MyState.Walk;
            SetAnimation("Walk");
        }
        else if(myState != MyState.Idle)
        {
            myState = MyState.Idle;
            SetAnimation("Idle");
        }

        Direction(x, z);

        Vector3 vec = new Vector3(x, 0, z);
        transform.position += vec * Speed * Time.deltaTime;
    }
    void SetAnimation(string name)
    {
        animator.SetTrigger(name);
    }
    void Direction(float x , float z)
    {
        float dir = 0;
        dir = Mathf.Lerp(dir, x, Time.deltaTime);
        Vector3 asd = x * Vector3.right + z * Vector3.forward;
        transform.rotation = Quaternion.LookRotation(asd);
    }
}
