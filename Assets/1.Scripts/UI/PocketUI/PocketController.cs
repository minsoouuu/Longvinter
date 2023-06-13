using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PocketController : MonoBehaviour
{
    [SerializeField] private List<PocketSlot> pocketSlots;
    [SerializeField] private Button escButton;
   
    private void Start()
    {
        escButton.onClick.AddListener(() => OnButtonDown());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            MonsterType type = (MonsterType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MonsterType)).Length +1);
            Debug.Log(type);
            Monster mon =  Gamemanager.instance.objectPool.GetObjectOfObjectPooling(type);
        }
    }
    public void AddItem(Item item)
    {
        for (int i = 0; i < pocketSlots.Count; i++)
        {
            if (pocketSlots[i].Item == null)
            {
                pocketSlots[i].Item = item;
                break;
            }
        }
    }
    void OnButtonDown()
    {
        // 풀링 반환
    }
}
