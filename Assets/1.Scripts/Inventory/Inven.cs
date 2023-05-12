using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    [SerializeField] private GameObject inven_tile;
    [SerializeField] private Transform parent;
 
    // Start is called before the first frame update
    void Start()
    {
        CreateInven();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateInven()
    {
        Instantiate(inven_tile, parent);
    }
}
