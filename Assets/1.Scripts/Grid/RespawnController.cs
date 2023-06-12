using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [HideInInspector] public List<GameObject> gb = new List<GameObject>();
    [HideInInspector] public float respawn_Time;

    public void Update()
    {
        RespawnTree();
    }
    public void RespawnTree()
    {
        respawn_Time += Time.deltaTime;
        if (respawn_Time > 2f)
        {
            if(gb.Count != 0)
            {
                gb[0].SetActive(true);
                gb.RemoveAt(0);
                respawn_Time = 0f;
            }
        }
    }
}
