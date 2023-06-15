using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FishingManager : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private Transform parent;
    private bool isIn = true;
    public bool IsOn { get; set; }
    private void Start()
    {
        IsOn = true;
    }
    private void Update()
    {
        if (isIn == false) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsOn == true)
            {
                IsOn = false;
                FishingController fishing = Gamemanager.instance.objectPool.GetObjectOfObjectPooling("FishingController");
                fishing.transform.SetParent(parent);
                fishing.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
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
