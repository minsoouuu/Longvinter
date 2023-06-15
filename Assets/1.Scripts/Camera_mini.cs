using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mini : MonoBehaviour
{
    
    private void Start()
    {
        
    }
    void Update()
    {
        transform.position = Gamemanager.instance.player.transform.position;
    }
}
