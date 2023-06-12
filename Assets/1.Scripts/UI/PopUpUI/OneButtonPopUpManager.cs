using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneButtonPopUpManager : MonoBehaviour
{
    public static OneButtonPopUpManager instance = null;
    private void Awake()
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
    public void SetComment(string commnet)
    {

    }
}
