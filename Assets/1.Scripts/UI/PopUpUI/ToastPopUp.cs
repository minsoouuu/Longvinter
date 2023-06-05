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
    private RectTransform popUprect;
    private string comment;
    private int count = 1;

    [HideInInspector] public Sequence sequence;

    private void OnEnable()
    {
        sequence.Restart();
        coroutine = StartCoroutine(PopUpHide());
    }
    private void OnDisable()
    {
        //sequence.onPause();
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
        sequence.SetAutoKill(false);
        sequence.OnStart(() => { ToastPopUpManager.instance.popUps.Add(this);});
        sequence.Append(popUprect.DOAnchorPosY(50, 2, true));
    }
    protected override void Initailize()
    {
        mypopType = PopType.ToastPopUp;
    }
    public void StopDoTween()
    {
        DOTween.Kill(this);
    }
    public void ReMove()
    {
        //count++;
        sequence.Append(popUprect.DOAnchorPosY(100, 2, true));
    }
    IEnumerator PopUpHide()
    {
        yield return new WaitForSeconds(5f);
        Sequence hideSequence = DOTween.Sequence();
        hideSequence.Append(popImage.DOFade(1f / 255f, 2));
        hideSequence.Append(commnetText.DOFade(1f / 255f, 0.5f));
        hideSequence.
            OnComplete(() =>
            {
                popImage.color = new Color(1, 1, 1, 1);
                commnetText.color = new Color(0, 0, 0, 1);
                popUprect.anchoredPosition = new Vector2(200, -50);
                Comment = string.Empty;
                count = 1;
                ToastPopUpManager.instance.popUps.Remove(this);
                base.ReturnObject();
            });
    }

    public override void SetComment(string comment)
    {
        commnetText.text = comment;
    }
}
