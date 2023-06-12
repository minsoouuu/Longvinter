using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class TwoButtonPopUpManager : MonoBehaviour
{
    public static TwoButtonPopUpManager instance = null;
    private PopUp twoButton;
    private Vector2 myPos = Vector2.zero;

    [SerializeField] private Transform popParent;

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SetCommnet("¤¾¤·", Test);
        }
    }
    public void SetCommnet(string comment, UnityAction action)
    {
        twoButton = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(PopType.TwoButtonPopUp);
        twoButton.transform.SetParent(popParent);
        twoButton.GetComponent<RectTransform>().anchoredPosition = myPos;
        twoButton.GetComponent<TwoButtonPopUp>().Action = action;
        twoButton.SetComment(comment);
    }
    void Test()
    {
        Debug.Log("¾×¼Ç");
    }
}
