using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    Inventory inventory = new Inventory();
    Slot slot = new Slot();
    [SerializeField] private Transform target = null;
    [SerializeField] private GameObject buttons;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        LeftClick_Item();
    }

    public void LeftClick_Item()
    {
        //??? ???? ??? ? ???? ?? ???
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = Camera.main.farClipPlane;

            target.position = Camera.main.ScreenToWorldPoint(pos);
            Debug.Log(target);

            Instantiate(buttons, target);
        }
    }

    public void ItemChuck()
    {
        slot.DeleteItem();
        Destroy(buttons);
    }

    public void ItemUse()
    {
        Debug.Log("???? ???????!");
        Destroy(buttons);
    }
  
}
