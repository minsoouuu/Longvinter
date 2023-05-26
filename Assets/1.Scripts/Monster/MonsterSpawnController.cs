using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private Transform spawnParent;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            Debug.Log("���� �Ŵ���");
            Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(monsters[0].monsterData.monsterType);
            monster.transform.SetParent(spawnParent);
            monster.transform.position = Gamemanager.instance.player.transform.position;
        }
    }
}
