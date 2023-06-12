using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{
    [SerializeField] private Image popUp;
    [SerializeField] private Transform parent;
    private bool isin = true;
    public bool IsOn { get; set; }
    private void Start()
    {
        IsOn = true;
    }
    private void Update()
    {
        if (isin == false) return;

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
            isin = true;
            popUp.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isin = false;
            popUp.gameObject.SetActive(false);
        }
    }
}
