using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PocketController : MonoBehaviour
{
    [SerializeField] private List<PocketSlot> pocketSlots;
    [SerializeField] private Button escButton;
    [SerializeField] private GameObject interUI;
    [SerializeField] private GameObject pocketUI;

    private List<Item> items = new List<Item>();
    private Coroutine coroutine;

    private bool isOpened = false;
    private bool isOpen = false;
    private void Start()
    {
        escButton.onClick.AddListener(() => OnButtonDownESC());
    }
    private void OnEnable()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(DeletePocket());
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
        float dis = Vector3.Distance(transform.position, Gamemanager.instance.player.transform.position);

        if (dis <= 1f)
        {
            if (isOpen != true)
            {
                interUI.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOpen = true;
                ShowItems();
                pocketUI.SetActive(true);
                interUI.SetActive(false);
            }
        }
        else
        {
            pocketUI.SetActive(false);
            isOpen = false;
            if (interUI.activeInHierarchy)
            {
                interUI.SetActive(false);
            }
        }

        if (pocketUI.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnButtonDownESC();
            }
        }
    }
    void ShowItems()
    {
        if (isOpened == false)
        {
            for (int i = 0; i < items.Count; i++)
            {
                pocketSlots[i].Item = items[i];
            }
            isOpened = true;
        }
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    void OnButtonDownESC()
    {
        for (int i = 0; i < pocketSlots.Count; i++)
        {
            if (pocketSlots[i].Item != null)
            {
                pocketUI.SetActive(false);
                return;
            }
        }
        ReturnObject();
    }
    void ReturnObject()
    {
        for (int i = 0; i < pocketSlots.Count; i++)
        {
            if (pocketSlots[i].Item != null)
            {
                pocketSlots[i].Item = null;
            }
        }
        items.Clear();
        isOpened = false;
        isOpen = false;
        pocketUI.SetActive(false);
        interUI.SetActive(false);
        Gamemanager.instance.objectPool.ReturnObject(this);
    }

    IEnumerator DeletePocket()
    {
        yield return new WaitForSeconds(300f);
        ReturnObject();
    }
}
