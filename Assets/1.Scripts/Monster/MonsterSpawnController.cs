using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private Transform monsterGroup;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private float spawnTime = 5f;
    
    public int monsterCount = 0;
    private int maxCount = 25;
    private float curTime;

    public GameObject rangeObject;
    private BoxCollider rangeCollider;

    public static MonsterSpawnController _instance;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _instance = this; 
    }


    private void Update()
    {
        if (curTime >= spawnTime && monsterCount < maxCount)
        {
            SpawnMonster();
        }
        curTime += Time.deltaTime;
    }

    public Vector3 GetRandomMovePoint()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float randPoint_x = rangeCollider.bounds.size.x;
        float randPoint_z = rangeCollider.bounds.size.z;

        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2);
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);
        Vector3 randPos = new Vector3(randPoint_x, 0f, randPoint_z);

        Vector3 respawnPosition = originPosition + randPos;
        return respawnPosition;
    }

    public void SpawnMonster()
    {
        curTime = 0;

        int rand = UnityEngine.Random.Range(0, 5);
        MonsterType type = (MonsterType)rand;

        // MonsterType type = (MonsterType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MonsterType)).Length);

        Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(type);
        monster.rangeCollider = rangeCollider;
        monster.transform.position = GetRandomMovePoint();
        monster.transform.SetParent(monsterGroup);
        

        if (monster.monsterAction != MonsterAction.IsWalking)
        {
            monster.monsterAction = MonsterAction.IsWalking;
        }

        monsterCount++;
    }
}
