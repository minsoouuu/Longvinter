using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwoButtonPopUp : PopUp
{
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private TMP_Text text;

    private string comment;
  
    protected override void Initailize()
    {
        mypopType = PopType.TwoButtonPopUp;
    }
    private void Start()
    {
        okButton.onClick.AddListener(() => OnButtonDownOK());
        cancelButton.onClick.AddListener(() => OnButtonDownCancel());
    }
    void OnButtonDownOK()
    {
        base.ReturnObject();
    }
    void OnButtonDownCancel()
    {
        base.ReturnObject();
    }

    public override void SetComment(string comment)
    {
        text.text = comment;
    }
}
