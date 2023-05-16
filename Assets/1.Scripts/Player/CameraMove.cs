using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Update is called once per frame
    Vector3 playerPos;

    float offsetX = 0;
    float offsetY = 4.5f;
    float offsetZ = -5.5f;
    private void Start()
    {
        
    }
    void Update()
    {
        playerPos = new Vector3(
               Gamemanager.instance.player.transform.position.x + offsetX,
               Gamemanager.instance.player.transform.position.y + offsetY,
               Gamemanager.instance.player.transform.position.z + offsetZ);

        transform.position = playerPos;
    }
}
