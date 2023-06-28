using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    [SerializeField] Transform canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < Gamemanager.instance.itemController.materilas.Count; i++)
            {
                Gamemanager.instance.player.im.ADItem(Gamemanager.instance.itemController.materilas[i], true);
            }
            for (int i = 0; i < Gamemanager.instance.itemController.plants.Count; i++)
            {
                Gamemanager.instance.player.im.ADItem(Gamemanager.instance.itemController.plants[i], true);
            }
            for (int i = 0; i < Gamemanager.instance.itemController.foods.Count; i++)
            {
                Gamemanager.instance.player.im.ADItem(Gamemanager.instance.itemController.foods[i], true);
            }
            for (int i = 0; i < Gamemanager.instance.itemController.equipments.Count; i++)
            {
                Gamemanager.instance.player.im.ADItem(Gamemanager.instance.itemController.equipments[i], true);
            }

            return;
            ToastPopUpManager.instance.Setcomment("ぞしぞし");
            PocketController po =  Gamemanager.instance.objectPool.GetObjectOfObjectPooling(0);
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(0, Gamemanager.instance.itemController.foods.Count);
                po.AddItem(Gamemanager.instance.itemController.GetItem(Gamemanager.instance.itemController.foods[rand].data.itemName,
                           Gamemanager.instance.itemController.foods[rand].data.itemType));
                Debug.Log($"{Gamemanager.instance.itemController.foods[rand].data.image}");
            }
        }
    }
}
