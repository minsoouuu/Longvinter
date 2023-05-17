using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenTabButton : MonoBehaviour
{
    public Toggle backpackTab;
    public Toggle equipTab;
    public Toggle collectionTab;

    public GameObject backpack;
    public GameObject equip;
    public GameObject collection;

    Button backpackBtn;
    Button equipBtn;
    Button collectionBtn;


    private void Awake()
    {
        backpackTab.isOn = true;
        equipTab.isOn = false;
        collectionTab.isOn = false;
    }

    private void Start()
    {
        backpackBtn = backpack.GetComponent<Button>();
        equipBtn = equip.GetComponent<Button>();
        collectionBtn = collection.GetComponent<Button>();
    }

    public void ToggleOn()
    {
        if (backpackTab.isOn)
        {
            backpack.SetActive(true);
            equip.SetActive(false);
            collection.SetActive(false);

            backpackBtn.onClick.Invoke();
            
        }
        else if (equipTab.isOn)
        {
            equip.SetActive(true);
            backpack.SetActive(false);
            collection.SetActive(false);

            equipBtn.onClick.Invoke();
        }
        else if (collectionTab.isOn)
        {
            collection.SetActive(true);
            backpack.SetActive(false);
            equip.SetActive(false);

            collectionBtn.onClick.Invoke();
        }
    }
    
    public void ButtonClick()
    {
        if (backpack)
        {
            
        }
    }

}
