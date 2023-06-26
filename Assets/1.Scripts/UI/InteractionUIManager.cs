using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionUIManager : MonoBehaviour
{
    [SerializeField] private Image uiObj;
    [SerializeField] private TMP_Text buttonText;
    public TMP_Text text;

    private bool isOn = false;
    public bool IsOn
    {
        get { return isOn; }
        set
        {
            isOn = value;
            uiObj.gameObject.SetActive(value);
        }
    }
    public void SetUi(string buttonText, string text)
    {
        this.buttonText.text = buttonText;
        this.text.text = text;
        uiObj.gameObject.SetActive(true);
    }
    public void DeleteUI()
    {
        buttonText.text = string.Empty;
        text.text = string.Empty;
        uiObj.gameObject.SetActive(false);
    }
}
