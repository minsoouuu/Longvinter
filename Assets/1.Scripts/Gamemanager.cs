using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance = null;

    public Player player;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
