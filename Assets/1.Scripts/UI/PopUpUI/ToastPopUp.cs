using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ToastPopUp : PopUp
{
    [SerializeField] private TMP_Text commnetText;

    private Coroutine coroutine;
    private Image popImage;

    [HideInInspector] public RectTransform popUprect;
    [HideInInspector] public Sequence sequence;

    private void OnEnable()
    {
        if (!ToastPopUpManager.instance.popUps.Contains(this))
        {
            ToastPopUpManager.instance.popUps.Add(this);
        }
        sequence.Append(popUprect.DOAnchorPosY(50, 1, true));
        coroutine = StartCoroutine(PopUpHide());
    }
    private void OnDisable()
    {
        popImage.color = new Color(1, 1, 1, 1);
        commnetText.color = new Color(0, 0, 0, 1);
        popUprect.anchoredPosition = new Vector2(200, -50);
        ToastPopUpManager.instance.popUps.Remove(this);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    private void Start()
    {
        popUprect = transform.GetChild(0).GetComponent<RectTransform>();
        popImage = transform.GetChild(0).GetComponent<Image>();
        sequence = DOTween.Sequence();
        sequence.Append(popUprect.DOAnchorPosY(50, 1, true));
        coroutine = StartCoroutine(PopUpHide());
    }
    protected override void Initailize()
    {
        mypopType = PopType.ToastPopUp;
    }
    public void Move(float finishPos)
    {
        sequence.Append(popUprect.DOAnchorPosY((popUprect.anchoredPosition.y + finishPos), 1f, true));
    }
    IEnumerator PopUpHide()
    {
        yield return new WaitForSeconds(5f);
        Sequence hideSequence = DOTween.Sequence();
        hideSequence.Append(popImage.DOFade(1f / 255f, 2));
        hideSequence.Append(commnetText.DOFade(1f / 255f, 2));
        yield return new WaitForSeconds(7f);
        ResetData();
    }
    void ResetData()
    {
        Comment = string.Empty;
        base.ReturnObject();
    }
    public override void SetComment(string comment)
    {
        commnetText.text = comment;
    }
}
