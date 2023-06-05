using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCountController : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text countText;

    ValueType myType = new ValueType();

    private int count = 0;
    private int calcNum = 0;
    public int Count
    {
        get { return count; }
        set 
        {
            count = value;
            countText.text = Count.ToString();
        }
    }
    private void Awake()
    {
        upButton.onClick.AddListener(() => OnButtonCountUp());
        downButton.onClick.AddListener(() => OnButtonCountDown());
        okButton.onClick.AddListener(() => OnButtonOK());
        Count = 0;
    }
    private void OnEnable()
    {
        Count = 0;
        calcNum = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    void OnButtonCountUp()
    {
        Count++;
        Debug.Log("증가");
    }
    void OnButtonCountDown()
    {
        if (Count <= 0)
            return;

        Count--;
        Debug.Log("감소");
    }
    void OnButtonOK()
    {
        Action();
        gameObject.SetActive(false);
        Debug.Log("확인");
    }
    void Action()
    {
        if (myType == ValueType.Money)
        {
            //Gamemanager.instance.inventory.Money -= Count;
        }
        else
        {
            //아이템 뺄때 
            //Gamemanager.instance.inventory.itemss
        }
    }
    public void SetValueType(ValueType valueType)
    {
        myType = valueType;
    }
}
