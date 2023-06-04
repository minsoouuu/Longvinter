using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private float spawnTime = 5f;
    
    public int MonsterCount = 0;
    private int maxCount = 15;
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
            Debug.Log("스폰 매니저");
            int x = Random.Range(0, spawnPoints.Length);
            SpawnMonster(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnMonster(int ranNum)
    {
        curTime = 0;
        MonsterCount++;
        Instantiate(monsters[Random.Range(0, monsters.Count)], spawnPoints[ranNum]);

        //Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(monsters[Random.Range(0, monsters.Count)].monsterData.monsterType);
        //monster.transform.SetParent(spawnPoints[ranNum]);
        //monster.transform.position = Gamemanager.instance.player.transform.position;
    }
}
