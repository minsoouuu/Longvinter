using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mini : MonoBehaviour
{
    Vector3 pos;

    float pos_x = 0f;
    float pos_y = 2.5f;
    float pos_z = 0f;
    private void Start()
    {
        
    }
    void Update()
    {
        pos = new Vector3(Gamemanager.instance.player.transform.position.x + pos_x, Gamemanager.instance.player.transform.position.y + pos_y, Gamemanager.instance.player.transform.position.z + pos_z);
        transform.position = pos;
    }
}
