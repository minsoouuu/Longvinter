using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Merchant : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text mk;
    [HideInInspector] public Item itemdata;
    Inventory inven = new Inventory();
    private void Start()
    {
        inven = Gamemanager.instance.inventory;
    }
   
    public void OnClickBuy()
    {
        itemdata.Init();
        inven.AddItem(itemdata);
        inven.Money -= itemdata.data.mk;
    }

    public void OnClickSell()
    {
        int count = 0;
        List<Item> temp = new List<Item>();
        temp = inven.equipments.ToList();
        count = temp.Count;
        inven.DeleteItem(itemdata);
        inven.Money += itemdata.data.mk;
        if(temp.Count != inven.equipments.Count)
        {
            for(int i = 0; i < temp.Count; i++)
            {
                Setdata(inven.equipments[i]);
            }
            for(int j = 0; j < Mathf.Abs(temp.Count - inven.equipments.Count); j++)
            {
                transform.parent.GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.itemImage;
        mk.text = itemdata.data.mk.ToString();
    }
    
    
}
