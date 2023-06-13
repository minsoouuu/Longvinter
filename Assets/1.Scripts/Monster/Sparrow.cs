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
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[4]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[5]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.materilas[3]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.materilas[4]);
    }

}
