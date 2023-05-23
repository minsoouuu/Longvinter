using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    Inventory inventory;
    Slot slot;
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
            GameObject showButtons = Instantiate(buttons, hit.transform);
            showButtons.transform.position = hit.transform.position;

            //?? ??? ?? ?? ? ?? ?? destroy ?? ??
        }
    }

    public void ItemChuck()
    {
        slot.DeleteItem();
        Destroy(buttons);
    }

    public void ItemUse()
    {
        slot.item.Action();
        Debug.Log("???? ???????.");
        Destroy(buttons);
    }
  
}
