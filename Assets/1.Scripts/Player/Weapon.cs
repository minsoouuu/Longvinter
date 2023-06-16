using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private User thePlayer;
    private Monster monster;

    public float speed = 5f;

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
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
