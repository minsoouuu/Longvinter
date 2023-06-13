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
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[0]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[1]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.materilas[0]);
    }
}
