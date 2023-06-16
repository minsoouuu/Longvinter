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

    // 거리에 따라 상인과 Player 상호작용
    public void Interaction_Merchant()
    {
        dis = Vector3.Distance(this.transform.position, Gamemanager.instance.player.transform.position);
        if (dis < 2f)
        {
            if (Input.GetKey(KeyCode.B))
            {
                merchant.SetActive(true);
                for(int i = 0; i < Gamemanager.instance.player.im.transform.childCount; i++)
                {
                    Gamemanager.instance.player.im.transform.GetChild(i).gameObject.SetActive(true);
                }
                
                Gamemanager.instance.player.GetComponent<User>().enabled = false;
                Gamemanager.instance.player.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
