using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_alignement : MonoBehaviour
{
    Inventory inventory = new Inventory();
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickAligne_Btn()
    {
        int slot_index = 0;
        for (int i=0; i < inventory.slots.Count; i++)
        {
            
            slot_index++;
        }
    }
}
