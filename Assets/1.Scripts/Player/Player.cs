using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MyState
{
    Idle,
    Walk,
    Run,
    Attack,
    Die
}
public abstract class Player : MonoBehaviour
{

    [SerializeField] private MyState myState = MyState.Idle;
    [SerializeField] private Animator animator;

    float maxHP = 100f;
    float speed = 3f;
    float curHP = 0f;
    float damage = 10f;

    State state;
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
        set { Damage = value; }
    }
    void Start()
    {
        curHP = maxHP;
    }
    void FixedUpdate()
    {
        if (myState.Equals(MyState.Die)) return;
        Walk();
    }
    void Update()
    {
        
    }
    void DoState()
    {
        switch (myState)
        {
            case MyState.Idle:
                state = gameObject.AddComponent<Idle>();
                state.Action();
                break;
            case MyState.Walk:
                state = gameObject.AddComponent<Walk>();
                state.Action();
                break;
            case MyState.Run:
                state = gameObject.AddComponent<Run>();
                state.Action();
                break;
            case MyState.Attack:
                state = gameObject.AddComponent<Attack>();
                state.Action();
                break;
        }
    }
    void Walk()
    {
        myState = MyState.Idle;
        DoState();
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Direction(x, z);
        Vector3 vec = new Vector3(x, 0, z);
        transform.position += vec * Speed * Time.deltaTime;
    }
    void Direction(float x , float z)
    {
        Vector3 dir = x * Vector3.right + z * Vector3.forward;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
