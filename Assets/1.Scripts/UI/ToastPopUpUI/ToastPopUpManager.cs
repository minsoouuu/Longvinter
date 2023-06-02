using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastPopUpManager : MonoBehaviour
{
    public static ToastPopUpManager toastmanager = null;

    private void Awake()
    {
        if (toastmanager != null)
        {
            Destroy(this);
        }
        else
        {
            toastmanager = this;
        }
    }



}
