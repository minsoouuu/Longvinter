using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantController : MonoBehaviour
{
    [SerializeField] private GameObject b_itemlist;
    [SerializeField] private Transform b_parent;
    [SerializeField] private GameObject s_itemlist;
    [SerializeField] private Transform s_parent;



    // Start is called before the first frame update
    void Start()
    {
        CreateMerchant_b_ItemList();
        CreateMerchant_s_ItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMerchant_b_ItemList()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(b_itemlist, b_parent);
        }
    }
    void CreateMerchant_s_ItemList()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(s_itemlist, s_parent);
        }
    }

    

    
}
