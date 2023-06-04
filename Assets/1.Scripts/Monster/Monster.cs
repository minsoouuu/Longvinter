using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct MonsterData
{
    public float speed;
    public float turningSpeed;
    public float hp;
    public Vector3 destination;
    public Vector3 direction;
    public MonsterType monsterType;
}

public abstract class Monster : MonoBehaviour
{
    public MonsterData monsterData = new MonsterData();
    MonsterAction monsterAction = new MonsterAction();
    private float curHp = 0;
    protected NavMeshAgent nav;

    protected enum MonsterAction
    {
        isIdle,
        isWalking,
        isRunning,
        isDead
    }

    [SerializeField] protected float waitTime;
    protected float currentTime;

    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected CapsuleCollider boxCol;

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
        nav = GetComponent<NavMeshAgent>();
        curHp = monsterData.hp;
        currentTime = waitTime;
        monsterAction = MonsterAction.isIdle;
        Debug.Log("¸ó½ºÅÍ »ý¼º");
    }

    protected void Update()
    {
        if (monsterAction != MonsterAction.isDead) 
        {
            Move();
            ElapseTime();
        }
    }

    public abstract void Initialize();

    protected virtual void Move()
    {
        if (monsterAction == MonsterAction.isWalking || monsterAction == MonsterAction.isRunning) 
        {
            nav.SetDestination(transform.position + monsterData.destination * 5f);
            // rigid.MovePosition(transform.position + transform.forward * monsterData.applySpeed * Time.deltaTime);
        }
    }

    protected virtual void Rotation()
    {
        if (monsterAction == MonsterAction.isWalking || monsterAction == MonsterAction.isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, monsterData.direction.y, 0f), monsterData.turningSpeed);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    protected void ElapseTime()
    {
        if (monsterAction == MonsterAction.isIdle)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0) 
                ReSet();
        }
    }

    protected virtual void ReSet() 
    {
        monsterAction = MonsterAction.isIdle;

        nav.ResetPath();

        monsterAction = MonsterAction.isWalking;
        anim.SetTrigger("Walking");
        monsterAction = MonsterAction.isRunning;
        anim.SetTrigger("Running");
        nav.speed = monsterData.speed;

        monsterData.destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
    }
    protected void Walk() 
    {
        monsterAction = MonsterAction.isWalking;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Walking");
        Debug.Log("°È±â");
    }

    protected virtual void Runaway(Vector3 _targetPos)
    {
        monsterData.destination = new Vector3(transform.position.x - _targetPos.x, 0f, transform.position.z - _targetPos.z).normalized;

        monsterAction = MonsterAction.isRunning;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Running");
        Debug.Log("µµ¸Á");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (monsterAction == MonsterAction.isDead) 
        {
            monsterData.hp -= _dmg;

            if (monsterData.hp <= 0)
            {
                MonsterDie();
                return;
            }

            anim.SetTrigger("Hurt");
            Runaway(_targetPos);
        }
    }

    protected void MonsterDie()
    {

        monsterAction = MonsterAction.isDead;
        anim.SetTrigger("Dead");
        MonsterSpawnController._instance.MonsterCount--;
        Destroy(this.gameObject); 
        DropItem();
    }

    public virtual void AreaCircle()
    {

    }
    public virtual void DropItem()
    {

    }


}
