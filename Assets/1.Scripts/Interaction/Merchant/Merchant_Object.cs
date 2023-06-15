using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Object : MonoBehaviour
{
    [SerializeField] private GameObject merchant;

    float dis;
    private void Update()
    {
        Interaction_Merchant();
    }

    public void Interaction_Merchant()
    {
        dis = Vector3.Distance(this.transform.position, Gamemanager.instance.player.transform.position);
        if (dis < 2f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                merchant.SetActive(true);
                Gamemanager.instance.player.im.gameObject.SetActive(true);
                Gamemanager.instance.player.GetComponent<User>().enabled = false;
                Gamemanager.instance.player.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
