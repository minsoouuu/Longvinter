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
        inventory.slots.Sort(delegate (Slot a, Slot b)
        {
            if(a.item != null || b.item != null)
            {
                return a.item.data.serialNum < b.item.data.serialNum ? -1 : 1;
            }
            else
            {
                return 0;
            }
        });
    }
}
