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
            Debug.Log("스폰 매니저");
            Monster monster = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(monsters[0].monsterData.monsterType);
            monster.transform.SetParent(spawnParent);
            monster.transform.position = Gamemanager.instance.player.transform.position;
        }
    }
}
