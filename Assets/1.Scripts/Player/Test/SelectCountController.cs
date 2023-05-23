using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCountController : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private TMP_Text countText;

    int count = 0;

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
        Count = 0;
    }
    public void OnButtonCountUp()
    {
        Count++;
    }
    public void OnButtonCountDown()
    {
        Count--;
    }
}
