using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ToastPopUpManager : MonoBehaviour
{
    public static ToastPopUpManager instance = null;

    [SerializeField] private Transform popParent;

    [HideInInspector] public List<ToastPopUp> popUps = new List<ToastPopUp>();

    PopUp toastPopUp;

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
    public void Setcomment(string comment)
    {
        if (popUps.Count > 0)
        {
            for (int i = 0; i < popUps.Count; i++)
            {
                popUps[i].Move(100);
            }
        }
        CreatePopUp(comment);
    }
    void CreatePopUp(string comment)
    {
        toastPopUp = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(PopType.ToastPopUp);
        toastPopUp.transform.SetParent(popParent);
        toastPopUp.SetComment(comment);
    }
}
