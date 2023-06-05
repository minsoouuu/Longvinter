using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ToastPopUpManager : MonoBehaviour
{
    public static ToastPopUpManager toastmanager = null;

    [SerializeField] private Transform popParent;

    [HideInInspector] public List<ToastPopUp> popUps = new List<ToastPopUp>();
    [HideInInspector] public List<DOTween> sequences = new List<DOTween>();
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
        if (Input.GetKeyDown(KeyCode.F2))
        {
        }
    }
    public void PopUpCommentSet(string comment)
    {
        if (popUps.Count > 0)
        {
            for (int i = 0; i < popUps.Count; i++)
            {
                popUps[i].Test((50 * (i + 1)));
            }
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
        toastPopUp.Test();
    }
}
