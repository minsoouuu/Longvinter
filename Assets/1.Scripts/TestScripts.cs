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
            ToastPopUpManager.instance.Setcomment("ぞしぞし");
            return;
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
