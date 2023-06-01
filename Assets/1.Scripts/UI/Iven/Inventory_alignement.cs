using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_alignement : MonoBehaviour
{
    Inventory inventory = new Inventory();
    
    

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickAligne_Btn()
    {
        for(int i = 0; i < SlotDataCount() - 1; i++)
        {
            /*
            if (inventory.slots[i].item.data.serialNum > inventory.slots[i + 1].item.data.serialNum)
            {
                Item1 tmp;
                tmp = inventory.slots[i].item;
                
                inventory.slots[i].item = inventory.slots[i + 1].item;
                inventory.slots[i].SetItemData(inventory.slots[i].item);
                
                inventory.slots[i + 1].item = tmp;
                inventory.slots[i+1].SetItemData(inventory.slots[i+1].item);
            }
            */
        }
    }

    public int SlotDataCount()
    {
        int s_count = 0;
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            //if (inventory.slots[i].item != null)
             //   s_count++;
        }
        return s_count;
    }
}
