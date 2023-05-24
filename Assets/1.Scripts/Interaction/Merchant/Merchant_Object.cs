using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Object : MonoBehaviour
{
    [SerializeField] private GameObject merchant;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");
            if (other.GetComponent<User>())
            {
                Debug.Log("true");
                merchant.SetActive(true);
                other.GetComponent<User>().enabled = false;
                other.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
