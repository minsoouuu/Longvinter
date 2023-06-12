using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneButtonPopUpManager : MonoBehaviour
{
    public static OneButtonPopUpManager instance = null;
    private Vector2 myPos = Vector2.zero;
    [SerializeField] private Transform popParent;
    PopUp oneButtonPop;
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
        CreatePopUp(commnet);
    }
    public void SetComment(string commnet, UnityAction action)
    {
        CreatePopUp(commnet, action);
    }
    void CreatePopUp(string comment)
    {
        oneButtonPop = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(PopType.OneButtonPopUp);
        oneButtonPop.transform.SetParent(popParent);
        oneButtonPop.GetComponent<RectTransform>().anchoredPosition = myPos;
        oneButtonPop.SetComment(comment);
    }
    void CreatePopUp(string comment,UnityAction action)
    {
        oneButtonPop = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(PopType.OneButtonPopUp);
        oneButtonPop.transform.SetParent(popParent);
        oneButtonPop.GetComponent<RectTransform>().anchoredPosition = myPos;
        oneButtonPop.SetComment(comment);
        oneButtonPop.GetComponent<OneButtonPopUp>().Action = action;
    }
}
