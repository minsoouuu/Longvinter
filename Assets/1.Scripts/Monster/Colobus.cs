using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colobus : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 1f;
        monsterData.monsterType = MonsterType.Colobus;
    }


    public override void DropItem()
    {
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[2]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.materilas[1]);
        pocketcontrol.AddItem(Gamemanager.instance.itemController.materilas[2]);
    }

}
