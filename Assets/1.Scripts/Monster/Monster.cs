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
        IsIdle,
        IsWalking,
        IsRunning,
        IsDead
    }
    public Vector3 pos;
    public MonsterData monsterData = new MonsterData();
    public MonsterType monstertype = new MonsterType();
    private MonsterAction monsterAction = new MonsterAction();
    private Vector3 destination;
    private User thePlayer;
    private float curHp = 0;
    protected float currentTime = 1;

    [SerializeField] protected NavMeshAgent nav;
    [SerializeField] protected Animator anim;

    [SerializeField] private float viewAngle;  // ???? ???? (130??)
    [SerializeField] private float viewDistance; // ???? ???? (10????)
    [SerializeField] private LayerMask targetMask;  // ???? ??????(????????)
    

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
        thePlayer = FindObjectOfType<User>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        curHp = monsterData.hp;
        monsterAction = MonsterAction.IsIdle;
    }

    protected void Update()
    {
        if (monsterAction != MonsterAction.IsDead)
        {
            Move();
            View();
        }
        if (View())
        {
            Runaway(thePlayer.transform.position);
        }

    }

    public abstract void Initialize();

    // ?????? ?????? ????????(??????)?? ?????? ?? ????
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

    IEnumerator Roaming()
    {
        destination.x = Random.Range(-90f, 90f);
        destination.z = Random.Range(-90f, 90f);
        
        Walk();
        while (true)
        {
            nav.SetDestination(transform.position + destination * 5f);

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.1f)
            {
                monsterAction = MonsterAction.IsIdle;
                yield return new WaitForSeconds(Random.Range(1f, 3f));
                destination.x = Random.Range(-90f, 90f);
                destination.z = Random.Range(-90f, 90f);
                Walk();
            }
            yield return null;
        }
    }

    // ?????? ????
    protected virtual void Move()
    {
        StartCoroutine(Roaming());
        /*
        if (monsterAction == MonsterAction.IsWalking || monsterAction == MonsterAction.IsRunning) 
        {
            nav.SetDestination(transform.position + destination * 5f);
            // rigid.MovePosition(transform.position + transform.forward * monsterData.applySpeed * Time.deltaTime);
        }
        */
    }

    /*
    // ???????? ???? ???? ??????
    protected void ElapseTime()
    {
        if (monsterAction == MonsterAction.IsIdle)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && monsterAction != MonsterAction.IsRunning)
                ReSet();
        }
    }
    

    // ???? ?????? ????
    protected virtual void ReSet() 
    {
        monsterAction = MonsterAction.IsIdle;
        nav.ResetPath();
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(-0.5f, 1f));
        Walk();
    }
    */

    // ?????? ????(???? ???? ?????????? ????) 
    protected void Walk() 
    {
        monsterAction = MonsterAction.IsWalking;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Walking");
        Debug.Log("Walk");
    }

    // ?????? ????(???????? ????!! -> View())
    protected virtual void Runaway(Vector3 _targetPos)
    {
        destination = new Vector3(transform.position.x - _targetPos.x, 0f, transform.position.z - _targetPos.z).normalized;

        monsterAction = MonsterAction.IsRunning;
        nav.speed = monsterData.speed;
        anim.SetTrigger("Running");
        Debug.Log("Runaway");
    }

    // ?????? ???? ???? (???????? ???? ?????? ???? ????)
    public virtual void Damage(int _dmg, Vector3 _targetPos)
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

    // ?????? Die
    protected void MonsterDie()
    {
        nav.enabled = false;
        monsterAction = MonsterAction.IsDead;
        anim.SetTrigger("Dead");
        //MonsterSpawnController._instance.MonsterCount--;

        Destroy(gameObject, 4);
        DropItem();
    }

    // ?????? ?????? ?????? ????
    public virtual void DropItem()     
    {
        Choose(new float[3] { 10f, 10f, 80f });     //???? 10%, ???? 10%, ???? 80%
        float Choose(float[] probs)
        {
            // ???????? ???? ???? ?????? ????
            return probs.Length - 1;
        }
    }


}
