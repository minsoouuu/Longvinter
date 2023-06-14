using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform monsterGroup;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private float spawnTime = 5f;
    
    public int monsterCount = 0;
    private int maxCount = 25;
    private float curTime;

    public static MonsterSpawnController _instance;

    private void Start()
    {
        _instance = this; 
    }
    private void Update()
    {
        if (curTime >= spawnTime && monsterCount < maxCount)
        {
            int x = UnityEngine.Random.Range(0, spawnPoints.Length);
            SpawnMonster(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnMonster(int ranNum) 
    {
        curTime = 0;
        MonsterType type = (MonsterType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MonsterType)).Length + 1);
        Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(type);
        monster.transform.SetParent(monsterGroup);
        monster.transform.position = new Vector3(spawnPoints[ranNum].position.x, spawnPoints[ranNum].position.y, spawnPoints[ranNum].position.z);
        monsterCount++;
    }
}
