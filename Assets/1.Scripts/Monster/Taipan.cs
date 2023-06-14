using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taipan : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 0.8f;
        monsterData.monsterType = MonsterType.Taipan;
    }


    public override void DropItem()
    {
        PocketController pocket = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(4);
        pocket.AddItem(Gamemanager.instance.itemController.materilas[5]);

        pocket.transform.position = transform.position;
        pocket.transform.SetParent(dropItemGroup);
    }
}
