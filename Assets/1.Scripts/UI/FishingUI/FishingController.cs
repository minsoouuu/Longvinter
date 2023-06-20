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

    [HideInInspector] public FishingManager fM;

    private List<Item> dropItems = new List<Item>();
    private float handleSpeed = 1000f;

    bool isTurn = true;
    bool isOn = true;
    Vector2 maxPos;
    private void Awake()
    {
        dropItems.Add(Gamemanager.instance.itemController.GetItem(ItemName.Tuna));
        dropItems.Add(Gamemanager.instance.itemController.GetItem(ItemName.Fuel));

        handleRT = handle.GetComponent<RectTransform>();
        maxPos = new Vector2(backRT.rect.xMax * 2, backRT.rect.yMax * 2);
    }
    private void OnEnable()
    {
        isOn = true;
        handleRT.anchoredPosition = new Vector2(-20, 0);
        //backRT.anchoredPosition = Vector2.zero;
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
                CreatePopUp(true);
            }
            else
            {
                isOn = false;
                CreatePopUp(false);
            }
        }
    }
    void CreatePopUp(bool isComplete)
    {
        if (isComplete)
        {
            OneButtonPopUpManager.instance.SetComment("성공", FinishEvent);
        }
        else
        {
            OneButtonPopUpManager.instance.SetComment("실패", FailEvent);
        }
    }
    void FinishEvent()
    {
        int rand = UnityEngine.Random.Range(0, dropItems.Count);
        Gamemanager.instance.player.im.ADItem(dropItems[rand], true);

        fM.IsOn = true;
        Gamemanager.instance.player.isMove = true;
        Gamemanager.instance.objectPool.ReturnObject(this);
    }
    void FailEvent()
    {
        fM.IsOn = true;
        Gamemanager.instance.player.isMove = true;
        Gamemanager.instance.objectPool.ReturnObject(this);
    }
}
