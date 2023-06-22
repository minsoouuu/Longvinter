using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Fish : MonoBehaviour
{
    public struct DropItem
    {
        public List<Item> items;
    }

    public enum State
    {
        Idle,
        Move,
        Die,
        Jump
    }

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;

    private Coroutine coroutine = null;

    public FishingManager fm;
    public DropItem dropItem = new DropItem();

    [SerializeField] private Vector3 nextPos;

    public State curState = State.Idle;


    private void Start()
    {
        Initillize();
        nextPos = GetRandomMovePoint();
        nav.SetDestination(nextPos);
       
    }
    public abstract void Initillize();
    private void OnEnable()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Jump());
        }
    }
    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    private void Update()
    {
        if (curState == State.Die)
            return;

        Move();
    }
    void Move()
    {
        Vector3 curPos = transform.position; // 현재 위치
        float dis = Vector3.Distance(curPos, nextPos); // 목표 위치
        
        if (dis <= 2f)
        {
            StartCoroutine(MoveWaitingTime());
        }
    }

    IEnumerator Jump()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);

        int randJumpPower = Random.Range(0, 10);
        Vector3 jump = new Vector3(0, randJumpPower, 0);

        while (true)
        {
            rigidbody.AddForce(jump, ForceMode.Impulse);
            Debug.Log("점프!");
            yield return wait;
        }
    }
    IEnumerator MoveWaitingTime()
    {
        curState = State.Idle;
        SetAnimation(curState);

        yield return new WaitForSeconds(1f);
        curState = State.Move;
        SetAnimation(curState);
        nextPos = GetRandomMovePoint();
        nav.SetDestination(nextPos);
        Debug.Log("대기");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            curState = State.Idle;
            SetAnimation(curState);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            curState = State.Jump;
            SetAnimation(curState);
        }
    }
    void SetAnimation(State state)
    {
        animator.SetTrigger(state.ToString());
    }
    Vector3 GetRandomMovePoint()
    {
        float randPoint_x = fm.boxCol.bounds.size.x;
        float randPoint_z = fm.boxCol.bounds.size.z;

        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2);
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);

        Vector3 randPos = new Vector3(randPoint_x, 0, randPoint_z);

        return randPos;
    }
}
