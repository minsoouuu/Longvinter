using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private float spawnTime = 5f;
    
    public int MonsterCount = 0;
    private int maxCount = 25;
    private float curTime;

    public static MonsterSpawnController _instance;

    private void Start()
    {
        _instance = this; 
    }
    private void Update()
    {
        if (curTime >= spawnTime && MonsterCount < maxCount)
        {
            int x = UnityEngine.Random.Range(0, monsters.Count);
            SpawnMonster(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnMonster(int ranNum)    //영역마다 5마리씩 스폰
    {
        curTime = 0;
        MonsterCount++;
        //Instantiate(monsters[Random.Range(0, monsters.Count)], spawnPoints[ranNum])

        /*
        int a =Enum.GetValues(typeof(Monster)).Length;
        Gamemanager.instance.objectPool.GetObjectOfObjectPooling(monsters[UnityEngine.Random.Range(0, a)].monsterData.monsterType);
        Debug.Log(monsters[UnityEngine.Random.Range(0, monsters.Count)].monsterData.monsterType);
        */
    }
}
