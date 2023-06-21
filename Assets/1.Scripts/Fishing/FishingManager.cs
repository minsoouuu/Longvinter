using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FishingManager : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private Transform parent;

    [HideInInspector] public BoxCollider boxCol;
    [HideInInspector] public int fishCount = 0;

    private bool isIn = true;
    public bool IsOn { get; set; }
    private void Start()
    {
        IsOn = true;
        StartCoroutine(FishSpawn());
    }
    private void Update()
    {
        if (isIn == false) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsOn == true)
            {
                IsOn = false;
                Gamemanager.instance.player.isMove = false;
                popUp.SetActive(false);
                FishingController fishing = Gamemanager.instance.objectPool.GetObjectOfObjectPooling("FishingController");
                fishing.transform.SetParent(transform);

                if (fishing.fM == null)
                {
                    fishing.fM = this;
                }
            }
        }
    }
    IEnumerator FishSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);

        while (fishCount <= 5)
        {
            if (fishCount <= 5)
            {
                Fish fish = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(FishName.Tuna);
                fish.transform.position = GetRandomSpawnPoint();
                fish.transform.SetParent(transform);
                fish.fm = this;
                fishCount++;
                yield return wait;
            }
        }
    }
    Vector3 GetRandomSpawnPoint()
    {
        float randPoint_x = boxCol.bounds.size.x;
        float randPoint_z = boxCol.bounds.size.z;

        randPoint_x = UnityEngine.Random.Range((randPoint_x / 2) * -1, randPoint_x / 2);
        randPoint_z = UnityEngine.Random.Range((randPoint_z / 2) * -1, randPoint_z / 2);

        Vector3 randPos = new Vector3(randPoint_x, 0, randPoint_z);

        return randPos + transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isIn = true;
            popUp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isIn = false;
            popUp.SetActive(false);
        }
    }
}
