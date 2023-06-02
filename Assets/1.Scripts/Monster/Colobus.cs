using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colobus : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 3f;
        monsterData.turningSpeed = 3f;
        monsterData.monsterType = MonsterType.Colobus;
    }

    public override void AreaCircle()
    {
        throw new System.NotImplementedException();
    }

    public override void DropItem()
    {
        throw new System.NotImplementedException();
    }

}
