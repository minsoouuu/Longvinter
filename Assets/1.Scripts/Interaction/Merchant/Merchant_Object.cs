using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Object : MonoBehaviour
{
    [SerializeField] private GameObject merchant;
    [SerializeField] private GameObject inventory;
    [SerializeField] private User user;

    float dis;
    private void Update()
    {
        Interaction_Merchant();
        Debug.Log(dis);
    }

    public void Interaction_Merchant()
    {
        dis = Vector3.Distance(this.transform.position, user.transform.position);
        if (dis < 2f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                merchant.SetActive(true);
                inventory.SetActive(true);
                user.GetComponent<User>().enabled = false;
                user.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
