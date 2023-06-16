using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingManager : MonoBehaviour
{
    [SerializeField] private GameObject interUI;
    [SerializeField] private MakingController mc;
    private void Update()
    {
        float dis = Vector3.Distance(transform.position, Gamemanager.instance.player.transform.position);

        if (dis <= 1)
        {
            if (mc.IsOn == false)
            {
                interUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    interUI.SetActive(false);
                    mc.transform.GetChild(0).gameObject.SetActive(true);
                    mc.IsOn = true;
                    Gamemanager.instance.player.im.mc = mc;

                    if (Gamemanager.instance.player.im.IsOn == false)
                    {
                        Gamemanager.instance.player.OnInventorySetActive();
                    }
                }
            }
        }
        else
        {
            interUI.SetActive(false);
        }
    }
}
