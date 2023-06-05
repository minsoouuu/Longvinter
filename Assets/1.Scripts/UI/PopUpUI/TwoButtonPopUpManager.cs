using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TwoButtonPopUpManager : MonoBehaviour
{
    public static TwoButtonPopUpManager instance = null;
  
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

    public void SetCommnet(string comment)
    {

    }
}
