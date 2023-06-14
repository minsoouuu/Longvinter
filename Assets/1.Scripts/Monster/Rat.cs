using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f; 
        monsterData.speed = 1f;
        monsterData.monsterType = MonsterType.Rat;
    }

    public override void DropItem()
    {
        PocketController pocket = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(2);
        pocket.AddItem(Gamemanager.instance.itemController.foods[0]);
        pocket.AddItem(Gamemanager.instance.itemController.foods[1]);
        pocket.AddItem(Gamemanager.instance.itemController.materilas[0]);

        pocket.transform.position = transform.position;
        pocket.transform.SetParent(dropItemGroup);
    }
}
