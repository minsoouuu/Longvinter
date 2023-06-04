using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct MonsterData
{
    public float speed;
    public float hp;
    public Vector3 direction;
    public MonsterType monsterType;
}

public abstract class Monster : MonoBehaviour
{
    protected enum MonsterAction
    {
        isIdle,
        isWalking,
        isRunning,
        isDead
    }

    protected float currentTime = 1;

    public MonsterData monsterData = new MonsterData();
    MonsterAction monsterAction = new MonsterAction();
    private Player thePlayer;
    private Vector3 destination;
    private float curHp = 0;

    [SerializeField] protected NavMeshAgent nav;
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;

    [SerializeField] private float viewAngle;  // 시야 각도 (130도)
    [SerializeField] private float viewDistance; // 시야 거리 (10미터)
    [SerializeField] private LayerMask targetMask;  // 타겟 마스크(플레이어)

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
        thePlayer = FindObjectOfType<Player>();
        this.nav = this.GetComponent<NavMeshAgent>();
        this.rigid = this.GetComponent<Rigidbody>();
        this.anim = this.GetComponent<Animator>();
        curHp = monsterData.hp;
        monsterAction = MonsterAction.isIdle;
        Debug.Log("몬스터 생성");
    }

    protected void Update()
    {
        if (monsterAction != MonsterAction.isDead)
        {
            Move();
            View();
            ElapseTime();
        }
        else if (View())
        {
            Runaway(thePlayer.transform.position);
        }
    }

    public abstract void Initialize();

    public bool View()
    {
        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if (_targetTf.name == "Player")
            {
                Vector3 _direction = (_targetTf.position - transform.position).normalized;
                float _angle = Vector3.Angle(_direction, transform.forward);

                if (_angle < viewAngle * 0.5f)
                {
                    RaycastHit _hit;
                    if (Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewDistance))
                    {
                        if (_hit.transform.name == "Player")
                        {
                            Debug.Log("플레이어가 시야 내에 있습니다.");
                            Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);

                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    protected virtual void Move()
    {
        if (monsterAction == MonsterAction.isWalking || monsterAction == MonsterAction.isRunning) 
        {
            nav.SetDestination(transform.position + destination * 5f);
            // rigid.MovePosition(transform.position + transform.forward * monsterData.applySpeed * Time.deltaTime);
        }
    }


    protected void ElapseTime()
    {
        if (monsterAction == MonsterAction.isIdle)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && monsterAction != MonsterAction.isRunning)
                ReSet();
        }
    }

    protected virtual void ReSet() 
    {
        monsterAction = MonsterAction.isIdle;
        nav.ResetPath();

        nav.speed = monsterData.speed;
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
        Walk();
    }

    protected void Walk() 
    {
        monsterAction = MonsterAction.isWalking;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Walking");
        Debug.Log("걷기");
    }

    protected virtual void Runaway(Vector3 _targetPos)
    {
        destination = new Vector3(transform.position.x - _targetPos.x, 0f, transform.position.z - _targetPos.z).normalized;

        monsterAction = MonsterAction.isRunning;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Running");
        Debug.Log("도망");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (monsterAction != MonsterAction.isDead) 
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

    public virtual void DropItem()
    {

    }


}
