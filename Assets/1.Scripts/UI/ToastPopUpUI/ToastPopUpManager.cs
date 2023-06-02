using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastPopUpManager : MonoBehaviour
{
    public static ToastPopUpManager toastmanager = null;

    [SerializeField] private Transform popParent;

    [HideInInspector] public Coroutine co = null;
    ToastPopUp toastPopUp;

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PopUpCommentSet("Áø±ÔÇü");
        }
    }


    public void PopUpCommentSet(string comment)
    {
        if (co == null)
        {
            SetPopUpData(comment);
        }
        else
        {
            SetPopUpData(comment);
        }
    }
    void SetPopUpData(string comment)
    {
        toastPopUp = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(PopType.ToastPopUp);
        toastPopUp.transform.SetParent(popParent);
        toastPopUp.Comment = comment;
        toastPopUp.ToastPopStart();
    }
}
