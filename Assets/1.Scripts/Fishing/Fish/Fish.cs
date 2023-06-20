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
    }

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Animator animator;

    public FishingManager fm;
    public DropItem dropItem = new DropItem();

    State curState = State.Idle;

    private void Start()
    {
        Initillize();
    }
    public abstract void Initillize();

    private void Update()
    {
       
    }
    
    void SetAnimation(string name)
    {
        animator.SetTrigger(name);
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
