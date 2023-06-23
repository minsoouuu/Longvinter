using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using System;
public abstract class Fish : MonoBehaviour
{
    public struct FishData
    {
        public List<Item> items;
        public float speed;
    }

    public enum State
    {
        Idle,
        Move,
        Die,
        Jump,
        Fear,
    }

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Animator animator;

    private Coroutine coroutine = null;

    public FishingManager fm;
    public FishData fishData = new FishData();
    public FishName fishName = new FishName();
    [SerializeField] private Vector3 nextPos;

    State curState = State.Idle;
    public bool IsIn { get; set; }
    private void Start()
    {
        Initillize();
        nextPos = GetRandomMovePoint();
        nav.SetDestination(nextPos);
        nav.speed = fishData.speed;
       
    }
    public abstract void Initillize();
    private void OnEnable()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Jump());
        }

        if (nav.enabled == false)
        {
            nav.enabled = true;
        }

        if (curState == State.Die)
        {
            curState = State.Move;
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

        float dis = Vector3.Distance(transform.position, Gamemanager.instance.player.transform.position);

        if (dis <= 1f)
        {
            if (IsIn == false && fm.IsOn == false)
            {
                IsIn = true;
                fm.IsOn = true;
            }
        }
        else
        { 
            if (IsIn == true)
            {
                IsIn = false;

                if (fm.IsOn == true)
                {
                    fm.IsOn = false;
                }
            }
        }

        if (IsIn == true && fm.IsOn == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("낚시 시작");
                nav.enabled = false;

                curState = State.Fear;
                SetAnimation(curState);

                FishingController fishing = Gamemanager.instance.objectPool.GetObjectOfObjectPooling("FishingController");
                fishing.transform.SetParent(fm.transform);

                if (fishing.fish == null)
                {
                    fishing.fish = this;
                }
            }
        }
        Move();
    }
    void Move()
    {
        Vector3 curPos = transform.position; // 현재 위치
        float dis = (curPos - nextPos).sqrMagnitude;
        
        if (dis <= 2f * 2f)
        {
            StartCoroutine(MoveWaitingTime());
        }
    }
    
    IEnumerator Jump()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);
        WaitForSeconds delay = new WaitForSeconds(1f);

        while (true)
        {
            if (curState != State.Jump)
            {
                curState = State.Jump;
                SetAnimation(curState);

                yield return delay;
                curState = State.Move;
                SetAnimation(curState);
                Debug.Log("점프!");

                yield return wait;
            }
        }
    }
    public IEnumerator MoveWaitingTime()
    {
        if (nav.enabled == false)
        {
            nav.enabled = true;
        }

        if (curState != State.Idle)
        {
            Debug.Log("대기");
            curState = State.Idle;
            SetAnimation(curState);

            yield return new WaitForSeconds(1f);
            curState = State.Move;
            SetAnimation(curState);
            nextPos = GetRandomMovePoint();
            nav.SetDestination(nextPos);
        }
    }
    void SetAnimation(State state)
    {
        animator.SetTrigger(state.ToString());
    }
    public void Die()
    {
        curState = State.Die;
        SetAnimation(curState);

        Gamemanager.instance.objectPool.ReturnObject(fishName, this);
        fm.fishCount--;
    }
    Vector3 GetRandomMovePoint()
    {
        float randPoint_x = fm.spawnZone.bounds.size.x;
        float randPoint_z = fm.spawnZone.bounds.size.z;

        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2);
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);

        Vector3 randPos = new Vector3(randPoint_x, 0, randPoint_z) + fm.transform.position;

        return randPos;
    }
}
