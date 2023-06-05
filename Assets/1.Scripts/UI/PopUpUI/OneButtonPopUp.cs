using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OneButtonPopUp : PopUp
{
    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text text;

 

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
        base.ReturnObject();
    }
}
