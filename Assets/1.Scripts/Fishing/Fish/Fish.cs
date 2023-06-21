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
    }

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Animator animator;

    public FishingManager fm;
    public DropItem dropItem = new DropItem();

    [SerializeField] private Vector3 nextPos;

    State curState = State.Idle;



    private void Start()
    {
        Initillize();
        nextPos = GetRandomMovePoint();
        nav.SetDestination(nextPos);
        Debug.Log(nextPos);
    }
    public abstract void Initillize();

    private void Update()
    {
        if (curState == State.Die)
            return;

    }
    void Move()
    {
        Vector3 curPos = transform.position; // 현재 위치
        float dis = Vector3.Distance(curPos, nextPos); // 목표 위치
        
        if (dis <= 2f)
        {
            StartCoroutine(MoveWaitingTime());
            Debug.Log(nextPos);
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
        Debug.Log(nextPos);
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

        return randPos + transform.position;
    }
}
