using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    public override void Use()
    {
        Gamemanager.instance.player.HP += data.stats;
        OneButtonPopUpManager.instance.SetComment($"HP를 {data.stats} 회복했습니다.");
    }
}
