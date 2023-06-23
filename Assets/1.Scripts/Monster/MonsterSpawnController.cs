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

        int rand = UnityEngine.Random.Range(0, 5);
        MonsterType type = (MonsterType)rand;

        // MonsterType type = (MonsterType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MonsterType)).Length);
        Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(type);
        monster.transform.position = new Vector3(spawnPoints[ranNum].localPosition.x, spawnPoints[ranNum].localPosition.y, spawnPoints[ranNum].localPosition.z);
        monster.transform.SetParent(monsterGroup);

        if (monster.monsterAction != MonsterAction.IsWalking)
        {
            monster.monsterAction = MonsterAction.IsWalking;
        }

        monsterCount++;
    }

    /*
    Vector3 GetRandomMovePoint()
    {
        1.몬스터를 생성할 구역(Collider)을 정하고.  *** 맵의 콜라이더를 사용해서 전체적인 구역에서 생성하기.(기존 4개는 일정한 좌표라 부자연스러울 수 있음)
                                                      - 낚시터,지어진 건물 안에선 생성 안되게 따로 예외 처리를 해야함.

                                                     ** 기존에 만들어진 스폰 포인트의 구역에서 랜덤좌표 구해 생성하기.
                                                      - 실시간 베이크 사용하기.
                                                      - 스폰포인트에 집 못짓게하기.

                                                      * 울타리 등을 이용하여 사냥터의 개념으로 일정 구역에서만 소환하기(사냥터 안에서만 이동) 
                                                      - 같은 방식으로 랜덤좌표 구하면 되니 nav 문제x
                                                      - 실시간 베이크를 안해도 되는 방법 (사냥터에선 집 못짓게 설정해야함)
                                                      - 맵 전체를 누비고 다니는것도 나쁘지 않아서 고민좀 해야됨.

                                                    결론 - 몬스터 생성과 이동을 구역안에서 랜덤하게(기존 4개 x)

    2. 영역의 사이즈를 측정(평면).
        float randPoint_x = 구역의 콜라이더.bounds.size.x;  
        float randPoint_z = 구역의 콜라이더.bounds.size.z;  

    3. float 값으로 영역의 사이즈 안에서 랜덤하게 값을 구함.
        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2); 
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);

    4. 구한 값의 x , z 를 Vector3값으로 만들어줌
        Vector3 randPos = new Vector3(randPoint_x, 0, randPoint_z);      

    5. 랜덤 좌표 반환
        return randPos; 
    }
    */
}
