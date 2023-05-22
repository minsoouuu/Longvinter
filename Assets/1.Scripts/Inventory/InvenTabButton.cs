using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenTabButton : MonoBehaviour
{

    Inven inven;

    public Toggle backpackTab;
    public Toggle equipTab;
    public Toggle collectionTab;

    private string nowToggle;

    public GameObject backpack;
    public GameObject equip;
    public GameObject collection;

    private void Awake()
    {
        backpackTab.isOn = true;
        equipTab.isOn = false;
        collectionTab.isOn = false;
    }

    public void ToggleOn()
    {
        if (backpackTab.isOn)
        {
            backpack.SetActive(true);
            equip.SetActive(false);
            collection.SetActive(false);
            nowToggle = backpack.name;
            for(int i = 0; i < inven.invenlist.Count; i++)
            {
                if (inven.prefab.nowType == (InvenItemType)2)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
                if (inven.prefab.nowType == (InvenItemType)3)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
            }
        }
        else if (equipTab.isOn)
        {
            equip.SetActive(true);
            backpack.SetActive(false);
            collection.SetActive(false);
            nowToggle = equip.name;
            for (int i = 0; i < inven.invenlist.Count; i++)
            {
                if (inven.prefab.nowType == (InvenItemType)1)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
                if (inven.prefab.nowType == (InvenItemType)3)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
            }
        }
        else if (collectionTab.isOn)
        {
            collection.SetActive(true);
            backpack.SetActive(false);
            equip.SetActive(false);
            nowToggle = collection.name;
            for (int i = 0; i < inven.invenlist.Count; i++)
            {
                if (inven.prefab.nowType == (InvenItemType)2)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
                if (inven.prefab.nowType == (InvenItemType)3)
                {
                    inven.invenlist[i].gameObject.SetActive(false);
                }
            }
        }
    }
    

}
