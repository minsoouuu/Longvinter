using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TwoButtonPopUp : PopUp
{
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private TMP_Text text;

    public UnityAction Action { get; set; }

    protected override void Initailize()
    {
        mypopType = PopType.TwoButtonPopUp;
    }
    private void Start()
    {
        okButton.onClick.AddListener(() => OnButtonDownOK());
        cancelButton.onClick.AddListener(() => OnButtonDownCancel());
    }
    public override void SetComment(string comment)
    {
        text.text = comment;
    }
    void OnButtonDownOK()
    {
        if (Action != null)
        {
            Action();
            AudioManager.instance.audio.Play();
        }
        Action = null;
        base.ReturnObject();
    }
    void OnButtonDownCancel()
    {
        if (Action != null)
        {
            AudioManager.instance.audio.Play();
            Action = null;
        }
        base.ReturnObject();
    }
}
