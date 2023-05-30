using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colobus : Monster
{
    public override void Initialize()
    {
        monsterData.hp = 100f;
        monsterData.speed = 5f;
        monsterData.monsterType = MonsterType.Colobus;
    }
}
