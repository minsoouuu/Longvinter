using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ToastPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text commnetText;
    [HideInInspector] public Coroutine coroutine;

    private RectTransform popUprect;
    private string comment;
    public string Comment
    {
        get { return comment; }
        set
        {
            comment = value;
            commnetText.text = $"{value} ȹ�� ! ";
        }
    }
    private void Awake()
    {
        popUprect = transform.GetChild(0).GetComponent<RectTransform>();
    }
    public void ToastPopStart()
    {
        ToastPopUpManager.toastmanager.coroutines.Add(this);
        coroutine = StartCoroutine(PopUpMove(1,50));
        StartCoroutine(PopUpHide());
    }

    public void Test(float yPos)
    {
        float maxPos = yPos;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(popUprect.DOAnchorPosY(maxPos, 2, true));
    }
    /// <summary>
    /// ó�� �����϶� 1�� , �߰��� �����϶� 0�� (���� ���ð�)
    /// </summary>
    /// <param name="waitngTime"></param> 
    /// <param name="maxPos"></param>
    /// <returns></returns>
    public IEnumerator PopUpMove(float waitngTime = 0, float maxPos = 0)
    {
        Sequence sequence = DOTween.Sequence();

        yield return new WaitForSeconds(waitngTime);
        sequence.Append(popUprect.DOAnchorPosY(maxPos, 2, true));
    }
    public IEnumerator PopUpHide()
    {
        Sequence sequence = DOTween.Sequence();

        yield return new WaitForSeconds(3f);
        sequence.Append(popUprect.GetComponent<Image>().DOFade(1 / 255f, 3));
        sequence.Append(commnetText.DOFade(1 / 255f, 3));

        yield return new WaitForSeconds(6f);
        Gamemanager.instance.objectPool.ReturnObject(PopType.ToastPopUp, this);
        ToastPopUpManager.toastmanager.coroutines.Remove(this);
    }
}
