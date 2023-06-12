using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishingController : MonoBehaviour
{
    [SerializeField] private RectTransform comPletePoint;
    [SerializeField] private HandleController handle;
    [SerializeField] private RectTransform handleRT;
    [SerializeField] private RectTransform backRT;

    private float handleSpeed = 1000f;

    bool isTurn = true;
    bool isOn = true;
    Vector2 maxPos;
    private void Awake()
    {
        handleRT = handle.GetComponent<RectTransform>();
        maxPos = new Vector2(backRT.rect.xMax * 2, backRT.rect.yMax * 2);
    }
    private void OnEnable()
    {
        isOn = true;
        handleRT.anchoredPosition = new Vector2(-20, 0);
        backRT.anchoredPosition = Vector2.zero;
        comPletePoint.anchoredPosition = new Vector2(UnityEngine.Random.Range(-100,100), 0);
    }
    private void Update()
    {
        if (isOn == false) return;

        if (isTurn)
        {
            if (handleRT.anchoredPosition.x <= maxPos.x)
            {
                handleRT.localPosition += Vector3.right * Time.deltaTime * handleSpeed;
            }
            else
            {
                isTurn = false;
            }
        }
        else
        {
            handleRT.localPosition += Vector3.left * Time.deltaTime * handleSpeed;
            if (handleRT.anchoredPosition.x <= 15)
            {
                isTurn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (handle.GetIsIn())
            {
                isOn = false;
                int rand = UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemName)).Length + 1);
                ItemName itemName = (ItemName)rand;
                Item item = Gamemanager.instance.itemController.GetItem(itemName);
                Gamemanager.instance.player.im.ADItem(item,true);
                CreatePopUp("성공");
            }
            else
            {
                isOn = false;
                CreatePopUp("실패");
            }
        }
    }
    void CreatePopUp(string commnet)
    {
        OneButtonPopUpManager.instance.SetComment(commnet, FinishEvent);
    }
    void FinishEvent()
    {
        Gamemanager.instance.fishing.IsOn = true;
        Gamemanager.instance.objectPool.ReturnObject(this);
    }
}
