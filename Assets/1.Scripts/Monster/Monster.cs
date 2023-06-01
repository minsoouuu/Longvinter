using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct MonsterData
{
    public float maxSpeed;
    public float hp;
    public Vector3 velocity;
    public MonsterType monsterType;
}

public abstract class Monster : MonoBehaviour
{
    public MonsterData monsterData = new MonsterData();
    private float curHp = 0;

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
        Debug.Log("몬스터 생성");
    }


    public abstract void Initialize();
    public virtual void AreaCircle()
    {

    }
    public virtual void Runaway()
    {

    }
    public virtual void DropItem()
    {

    }
    public virtual void MonsterDie()
    {

    }


}
