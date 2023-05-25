using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_interaction : MonoBehaviour
{
    [SerializeField] private GameObject inter_btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<User>())
        {
            inter_btn.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<User>())
        {
            inter_btn.SetActive(false);
        }
    }
}
