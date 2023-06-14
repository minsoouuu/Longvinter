using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f; 
        monsterData.speed = 1.5f;
        monsterData.monsterType = MonsterType.Sparrow;
    }

    public override void DropItem()
    {
        PocketController pocket = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(3);
        pocket.AddItem(Gamemanager.instance.itemController.foods[4]);
        pocket.AddItem(Gamemanager.instance.itemController.foods[5]);
        pocket.AddItem(Gamemanager.instance.itemController.materilas[3]);
        pocket.AddItem(Gamemanager.instance.itemController.materilas[4]);

        pocket.transform.position = transform.position;
        pocket.transform.SetParent(dropItemGroup);
    }

}
