using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gecko : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 0.5f;
        monsterData.monsterType = MonsterType.Gecko;
    }

    public override void DropItem()
    {
        pocketcontrol.AddItem(Gamemanager.instance.itemController.foods[3]);
    }
}
