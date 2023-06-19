using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject sparkEffect;
    [SerializeField] private float speed = 50f;

    private User thePlayer;

    public WeaponName myName = new WeaponName();

    public abstract void Initallize();
    private void Start()
    {
        thePlayer = Gamemanager.instance.player;
        Initallize();
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed * -1);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Monster")
        {
            Monster m = target.GetComponent<Monster>();
            m.Damage(999, thePlayer.transform.position);
            //ShowEffect(target);
            ReturnObject();
        }
    }

    void ShowEffect(Collision target)
    {
        ContactPoint contact = target.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
        GameObject spark = Instantiate(sparkEffect, contact.point - (contact.normal * 0.5f), rot);
        spark.transform.SetParent(this.transform);
    }

    void ReturnObject()
    {
        Gamemanager.instance.objectPool.ReturnObject(myName,this);
    }

    void OnBecameInvisible()
    {
        ReturnObject();
        //Destroy(this.gameObject);
    }
}
