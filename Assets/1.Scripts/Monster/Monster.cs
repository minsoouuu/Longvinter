using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct MonsterData
{
    public float walkSpeed;
    public float runSpeed;
    public float turningSpeed;
    public float applySpeed;
    public float hp;
    public Vector3 destination;
    public Vector3 direction;
    public MonsterType monsterType;
}

public abstract class Monster : MonoBehaviour
{
    public MonsterData monsterData = new MonsterData();
    private float curHp = 0;
    protected NavMeshAgent nav;

    protected bool isIdle;
    protected bool isWalking;
    protected bool isRunning;
    protected bool isDead;


    [SerializeField] protected float walkTime;
    [SerializeField] protected float waitTime;
    [SerializeField] protected float runTime;
    protected float currentTime;

    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected BoxCollider boxCol;

    public float HP
    {
        get { return curHp; }
        set { curHp = value; }
    }
    void Awake()
    {
        Initialize();
    }
    private void Start()
    {
        curHp = monsterData.hp;
        currentTime = waitTime;
        isIdle = true;
        Debug.Log("¸ó½ºÅÍ »ý¼º");
    }

    protected void Update()
    {
        if (!isDead)
        {
            Move();
            Rotation();
        }
    }
    public abstract void Initialize();

    protected virtual void Move()
    {
        if (isWalking || isRunning)
        {
            rigid.MovePosition(transform.position + transform.forward * monsterData.applySpeed * Time.deltaTime);
        }
    }

    protected virtual void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, monsterData.direction.y, 0f), monsterData.turningSpeed);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }
    protected void Walk() 
    {
        currentTime = walkTime;
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        monsterData.applySpeed = monsterData.walkSpeed;
        Debug.Log("°È±â");
    }

    protected virtual void Runaway(Vector3 _targetPos)
    {
        monsterData.direction = Quaternion.LookRotation(transform.position - _targetPos).eulerAngles;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        monsterData.applySpeed = monsterData.runSpeed;
        anim.SetBool("Running", isRunning);
        Debug.Log("µµ¸Á");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            monsterData.hp -= _dmg;

            if (monsterData.hp <= 0)
            {
                MonsterDie();
                return;
            }

            anim.SetTrigger("Hurt");
            if (!isDead)
            {
                Runaway(_targetPos);
            }
        }
    }

    protected void MonsterDie()
    {
        
        isWalking = false;
        isRunning = false;
        isDead = true;

        anim.SetTrigger("Dead");
    }

    public virtual void AreaCircle()
    {

    }
    public virtual void DropItem()
    {

    }


}
