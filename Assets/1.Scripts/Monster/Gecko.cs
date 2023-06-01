using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gecko : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.maxSpeed = 3f;
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

    public override void MonsterDie()
    {
        throw new System.NotImplementedException();
    }

    public override void Runaway()
    {
        throw new System.NotImplementedException();
    }
}
