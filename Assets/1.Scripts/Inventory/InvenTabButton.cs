using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenTabButton : MonoBehaviour
{

    [SerializeField] private ItemData[] itemData;

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
    
    //토글 눌렸을 때 Type에 맞는 아이템 보여주기
    public void ButtonClick()
    {
        switch (nowToggle)
        {
            case "Backpack":
                ItemData.InvenItemType.Backpack
                break;
            case "Equipment":

                break;
            case "Collection":

                break;
        }
            
    }

}
