using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    // ???????? ?????? ????. true : ?????? ?????? ?? ???? ???? ????
    public static bool invectoryActivated = false;

    [SerializeField] public Slot prefab;
    [SerializeField] private Item[] itemData;
    [SerializeField] private GameObject invenBG;
    [SerializeField] private Transform parent;

    public Item sample;


    public List<Slot> invenlist = new List<Slot>();

    [HideInInspector] public int InvenX { get; set; }
    [HideInInspector] public int InvenY { get; set; }



    void Start()
    {
        // ?????????? ???? 4??, ?????? 5?? ?? 20??
        InvenX = 4;
        InvenY = 5;
        gameObject.SetActive(false);
        CreateInven();
    }

    void Update()
    {
        KeyOpenInventory();
        Test();
    }

    // ???????? ???? ???? ????
    public void CreateInven()
    {
        for(int i = 0; i < InvenX * InvenY; i++)
        {
            Slot gb =  Instantiate(prefab, parent);
            invenlist.Add(gb);
        }
    }

    private void KeyOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invectoryActivated = !invectoryActivated;

            if (invectoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        invenBG.SetActive(true);
    }

    private void CloseInventory()
    {
        invenBG.SetActive(false);
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //invenlist[0].SetData(sample);
        }
    }
    
}
