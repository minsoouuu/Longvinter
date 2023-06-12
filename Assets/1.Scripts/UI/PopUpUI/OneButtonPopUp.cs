using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class OneButtonPopUp : PopUp
{
    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text text;
    public UnityAction Action { get; set; }
    public override void SetComment(string comment)
    {
        text.text = comment;
    }
    protected override void Initailize()
    {
        mypopType = PopType.OneButtonPopUp;
    }
    private void Awake()
    {
        okButton.onClick.AddListener(() => OnButtonDownOk());
    }
    void OnButtonDownOk()
    {
        if (Action != null)
        {
            Action();
        }
        Action = null;
        base.ReturnObject();
    }
}
