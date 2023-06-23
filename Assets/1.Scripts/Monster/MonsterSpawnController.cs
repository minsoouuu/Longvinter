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
        1.���͸� ������ ����(Collider)�� ���ϰ�.  *** ���� �ݶ��̴��� ����ؼ� ��ü���� �������� �����ϱ�.(���� 4���� ������ ��ǥ�� ���ڿ������� �� ����)
                                                      - ������,������ �ǹ� �ȿ��� ���� �ȵǰ� ���� ���� ó���� �ؾ���.

                                                     ** ������ ������� ���� ����Ʈ�� �������� ������ǥ ���� �����ϱ�.
                                                      - �ǽð� ����ũ ����ϱ�.
                                                      - ��������Ʈ�� �� �������ϱ�.

                                                      * ��Ÿ�� ���� �̿��Ͽ� ������� �������� ���� ���������� ��ȯ�ϱ�(����� �ȿ����� �̵�) 
                                                      - ���� ������� ������ǥ ���ϸ� �Ǵ� nav ����x
                                                      - �ǽð� ����ũ�� ���ص� �Ǵ� ��� (����Ϳ��� �� ������ �����ؾ���)
                                                      - �� ��ü�� ����� �ٴϴ°͵� ������ �ʾƼ� ����� �ؾߵ�.

                                                    ��� - ���� ������ �̵��� �����ȿ��� �����ϰ�(���� 4�� x)

    2. ������ ����� ����(���).
        float randPoint_x = ������ �ݶ��̴�.bounds.size.x;  
        float randPoint_z = ������ �ݶ��̴�.bounds.size.z;  

    3. float ������ ������ ������ �ȿ��� �����ϰ� ���� ����.
        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2); 
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);

    4. ���� ���� x , z �� Vector3������ �������
        Vector3 randPos = new Vector3(randPoint_x, 0, randPoint_z);      

    5. ���� ��ǥ ��ȯ
        return randPos; 
    }
    */
}
