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
    private Coroutine coroutine = null;

    public abstract void Initallize();
    private void Start()
    {
        thePlayer = Gamemanager.instance.player;
        Initallize();
    }

    private void OnEnable()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine("Disappear");
        }
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //GetComponent<Rigidbody>().AddForce(transform.up * speed *-1);
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2.0f);

        try
        {
            ReturnObject();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Monster")
        {
            Monster m = target.GetComponent<Monster>();
            m.Damage(999, thePlayer.transform.position);
            //ShowEffect(target);

            try
            {
                ReturnObject();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    /*
    void ShowEffect(Collision target)
    {
        ContactPoint contact = target.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
        GameObject spark = Instantiate(sparkEffect, contact.point - (contact.normal * 0.5f), rot);
        spark.transform.SetParent(this.transform);
    }
    */

    void ReturnObject()
    {
        Gamemanager.instance.objectPool.ReturnObject(myName,this);
    }

}
