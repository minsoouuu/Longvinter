using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gecko : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 3f;
        monsterData.monsterType = MonsterType.Gecko;
    }
}
