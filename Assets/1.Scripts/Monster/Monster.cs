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

    public MonsterData monsterData = new MonsterData();
    private MonsterAction monsterAction = new MonsterAction();
    public Player thePlayer;
    private Vector3 destination;
    private float curHp = 0;
    protected float currentTime = 1;

    [SerializeField] protected NavMeshAgent nav;
    [SerializeField] protected Animator anim;

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
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        curHp = monsterData.hp;
        monsterAction = MonsterAction.isIdle;
        Debug.Log("몬스터 생성");
    }

    protected void Update()
    {
        if (monsterAction != MonsterAction.isDead)
        {
            ElapseTime();
            Move();
            View();
        }
        if (View())
        {
            Runaway(thePlayer.transform.position);  // 위치 왜 못 잡아???????
        }

    }

    public abstract void Initialize();

    // 몬스터 시야에 플레이어(레이어)가 잡히는 지 검사
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

    // 몬스터 출발
    protected virtual void Move()
    {
        if (monsterAction == MonsterAction.isWalking || monsterAction == MonsterAction.isRunning) 
        {
            nav.SetDestination(transform.position + destination * 5f);
            // rigid.MovePosition(transform.position + transform.forward * monsterData.applySpeed * Time.deltaTime);
        }
    }

    // 도착하고 나서 잠시 멈추기
    protected void ElapseTime()
    {
        if (monsterAction == MonsterAction.isIdle)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && monsterAction != MonsterAction.isWalking && monsterAction != MonsterAction.isRunning)
                ReSet();
        }
    }

    // 랜덤 도착지 설정
    protected virtual void ReSet() 
    {
        monsterAction = MonsterAction.isIdle;
        nav.ResetPath();
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
        Walk();
    }

    // 몬스터 걷기(랜덤 영역 돌아다니게 하기)
    protected void Walk() 
    {
        monsterAction = MonsterAction.isWalking;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Walking");
        Debug.Log("걷기");
    }

    // 몬스터 도망(플레이어 보면!! -> View())
    protected virtual void Runaway(Vector3 _targetPos)
    {
        destination = new Vector3(transform.position.x - _targetPos.x, 0f, transform.position.z - _targetPos.z).normalized;

        monsterAction = MonsterAction.isRunning;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Running");
        Debug.Log("도망");
    }

    // 몬스터 공격 당함 (플레이어 공격 함수와 연동 필요)
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

    // 몬스터 Die
    protected void MonsterDie()
    {
        nav.enabled = false;
        monsterAction = MonsterAction.isDead;
        anim.SetTrigger("Dead");
        MonsterSpawnController._instance.MonsterCount--;

        Destroy(gameObject, 4);
        DropItem();
    }

    // 몬스터 죽으면 아이템 드랍
    public virtual void DropItem()     
    {
        Choose(new float[3] { 10f, 10f, 80f });     //장비 10%, 요리 10%, 재료 80%
        float Choose(float[] probs)
        {
            float total = 0;
            foreach(float elem in probs)
            {
                total += elem;
            }
            float randomPoint = Random.value * total;

            for(int i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                {
                    switch (i)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break; 

                    }
                    return i;
                }
                else
                {
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
    }


}
