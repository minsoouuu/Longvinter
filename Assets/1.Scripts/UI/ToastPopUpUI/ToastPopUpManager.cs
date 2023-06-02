using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastPopUpManager : MonoBehaviour
{
    public static ToastPopUpManager toastmanager = null;

    [SerializeField] private Transform popParent;

    [HideInInspector] public List<ToastPopUp> coroutines = new List<ToastPopUp>();
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
            PopUpCommentSet("***");
        }
    }
    public void PopUpCommentSet(string comment)
    {
        if (coroutines.Count <= 0)
        {
            SetPopUpData(comment);
        }
        else
        {
            for (int i = 0; i < coroutines.Count; i++)
            {
                coroutines[i].StopCoroutine(coroutines[i].coroutine);
                coroutines[i].StartCoroutine(coroutines[i].PopUpMove(0,(50 * (coroutines.Count - i))));
            }
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
