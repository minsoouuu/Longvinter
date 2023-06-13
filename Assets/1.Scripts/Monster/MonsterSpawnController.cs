using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
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

    public void SpawnMonster(int ranNum)    //???????? 5?????? ????
    {
        curTime = 0;
        monsterCount++;
        Instantiate(monsters[UnityEngine.Random.Range(0, monsters.Count)], spawnPoints[ranNum]);
        // Gamemanager.instance.objectPool.GetObjectOfObjectPooling(monsters[UnityEngine.Random.Range(0, monsters.Count)].monsterData.monsterType);
        // monsters[].transform.SetParent(spawnPoints[ranNum]);
        // monsters[].transform.position = Gamemanager.instance.player.transform.position;
        // Debug.Log(monsters[UnityEngine.Random.Range(0, monsters.Count)].monsterData.monsterType);
    }
}
