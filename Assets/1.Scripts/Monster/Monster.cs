using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct MonsterData
{
    public float speed;
    public float hp;
    public MonsterType monsterType;
}
public enum MonsterAction
{
    IsIdle,
    IsWalking,
    IsRunning,
    IsDead
}
public abstract class Monster : MonoBehaviour
{
   

    public Vector3 pos;
    public List<Transform> wayPoints;
    public int nextIdx = 0;
    public MonsterData monsterData = new MonsterData();
    [HideInInspector] public MonsterAction monsterAction = new MonsterAction();
    private Vector3 destination;
    private User thePlayer;
    private float curHp = 0;
    protected float currentTime = 1;

    [SerializeField] protected NavMeshAgent nav;
    [SerializeField] protected Animator anim;
    [SerializeField] public Transform dropItemGroup;

    [SerializeField] private float viewAngle;
    [SerializeField] private float viewDistance; 
    [SerializeField] private LayerMask targetMask;
    
    public float HP
    {
        get { return curHp; }
        set
        {
            curHp = value;

            if (curHp <= 0)
            {
                MonsterDie();
            }
        }
        
    }

    private void OnEnable()
    {
        nav.enabled = true;
        Move();
    }

    void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        thePlayer = Gamemanager.instance.player;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.autoBraking = false;
        curHp = monsterData.hp;
        monsterAction = MonsterAction.IsIdle;

        var group = GameObject.Find("WayPointGroup");

        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
        }

        Move();
    }

    protected void Update()
    {
        if (nav.velocity.sqrMagnitude >= 0.2f * 0.2f && nav.remainingDistance <= 0.5f && monsterAction != MonsterAction.IsDead) 
        {
            Move();
            View();
        }
        if (View()) 
        {
            Runaway(thePlayer.transform.position);
        }
        Test();
    }

    public abstract void Initialize();

    // If hit by or close to the player, they will runaway.
    public bool View()
    {
        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTrans = _target[i].transform;
            if (_targetTrans.name == "Player")
            {
                Vector3 _direction = (_targetTrans.position - transform.position).normalized;
                float _angle = Vector3.Angle(_direction, transform.forward);

                if (_angle < viewAngle * 0.5f)
                {
                    RaycastHit _hit;
                    if (Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewDistance))
                    {
                        if (_hit.transform.name == "Player")
                        {
                            Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);

                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }



    protected void Move()
    {
        Walk();

        if (monsterAction == MonsterAction.IsWalking)
        {
            nextIdx = Random.Range(0, wayPoints.Count);

            if (nav.isPathStale)
            {
                return;
            }

            nav.destination = wayPoints[nextIdx].position;
            // nav.SetDestination(transform.position + destination * 5f);}
        }
    }

    protected void Walk() 
    {
        monsterAction = MonsterAction.IsWalking;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Walking");
    }

    protected void Runaway(Vector3 _targetPos)
    {
        destination = new Vector3(transform.position.x - _targetPos.x, 0f, transform.position.z - _targetPos.z).normalized;

        monsterAction = MonsterAction.IsRunning;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Running");
        Debug.Log("Runaway");
    }

    protected void Damage(int _dmg, Vector3 _targetPos)
    {
        if (monsterAction != MonsterAction.IsDead) 
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
        nav.enabled = false;
        monsterAction = MonsterAction.IsDead;
        anim.SetTrigger("Dead");
        DropItem();

        HP = monsterData.hp;
        Gamemanager.instance.objectPool.ReturnObject(monsterData.monsterType, this);
        MonsterSpawnController._instance.monsterCount--;
       
    }

    public virtual void DropItem()     
    {
    }


    protected void Test()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            HP -= 99999;
        }
    }

}
