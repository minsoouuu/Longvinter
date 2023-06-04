using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f; 
        monsterData.speed = 2f;
        monsterData.monsterType = MonsterType.Sparrow;
    }

    public override void DropItem()
    {
        throw new System.NotImplementedException();
    }

}
