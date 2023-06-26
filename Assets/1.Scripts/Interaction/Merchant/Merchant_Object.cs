using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Object : MonoBehaviour
{
    [SerializeField] private GameObject merchant;

    float dis;
    [HideInInspector] public bool ison;

    private void Start()
    {
        ison = false;
    }
    private void Update()
    {
        Interaction_Merchant();
    }

    // �Ÿ��� ���� ���ΰ� Player ��ȣ�ۿ�
    public void Interaction_Merchant()
    {
        dis = Vector3.Distance(this.transform.position, Gamemanager.instance.player.transform.position);
        if (dis < 2f)
        {
            if (ison == false)
            {
                ison = true;
                Gamemanager.instance.interUI.IsOn = true;
                Gamemanager.instance.interUI.SetUi("B", "��������");
            }
            if (Input.GetKey(KeyCode.B))
            {
                merchant.SetActive(true);
                for(int i = 0; i < Gamemanager.instance.player.im.transform.childCount; i++)
                {
                    Gamemanager.instance.player.im.transform.GetChild(i).gameObject.SetActive(true);
                }
                if(ison == true)
                {
                    Gamemanager.instance.interUI.SetUi("ESC", "�����ݱ�");
                }
                Gamemanager.instance.player.GetComponent<User>().enabled = false;
                Gamemanager.instance.player.GetComponent<Animator>().enabled = false;
            }
        }
        else
        {
            if (ison == true)
            {
                ison = false;
                Gamemanager.instance.interUI.DeleteUI();
                Gamemanager.instance.interUI.IsOn = false;
            }
        }
    }
}
