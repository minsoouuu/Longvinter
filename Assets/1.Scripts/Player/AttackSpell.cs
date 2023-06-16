using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : MonoBehaviour
{
    private User thePlayer;
    private Monster monster;

    private void Update()
    {
        transform.Translate(Vector3.forward * 1f);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag.Equals("Monster"))
        {
            monster.Damage(10, thePlayer.transform.position);

            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다.
    }
}
