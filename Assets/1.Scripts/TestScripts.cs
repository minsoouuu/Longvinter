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
            PocketController po =  Gamemanager.instance.objectPool.GetObjectOfObjectPooling(0);
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(0, Gamemanager.instance.itemController.equipments.Count);
                po.AddItem(Gamemanager.instance.itemController.equipments[rand]);
            }
        }
    }
}
