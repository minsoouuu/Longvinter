using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenTabButton : MonoBehaviour
{

    [SerializeField] private Item[] itemData;

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
            //ItemData.InvenItemType.Backpack
        }
        else if (equipTab.isOn)
        {
            equip.SetActive(true);
            backpack.SetActive(false);
            collection.SetActive(false);
            nowToggle = equip.name;

        }
        else if (collectionTab.isOn)
        {
            collection.SetActive(true);
            backpack.SetActive(false);
            equip.SetActive(false);
            nowToggle = collection.name;

        }
    }
    

}
