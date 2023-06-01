using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gecko : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.walkSpeed = 3f;
        monsterData.runSpeed = 5f;
        monsterData.turningSpeed = 3f;
        monsterData.monsterType = MonsterType.Gecko;
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
