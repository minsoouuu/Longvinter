using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taipan : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.walkSpeed = 4f;
        monsterData.runSpeed = 7f;
        monsterData.turningSpeed = 3f;
        monsterData.monsterType = MonsterType.Taipan;
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
