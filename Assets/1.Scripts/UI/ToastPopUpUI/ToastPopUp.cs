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

    private Image popImage;
    private RectTransform popUprect;
    private string comment;

    Sequence sequence = DOTween.Sequence();

    public string Comment
    {
        get { return comment; }
        set
        {
            comment = value;
            commnetText.text = $"{value} »πµÊ ! ";
        }
    }
    private void Awake()
    {
        popUprect = transform.GetChild(0).GetComponent<RectTransform>();
        popImage = transform.GetChild(0).GetComponent<Image>();
    }
    private void Start()
    {
        
    }
    public void ToastPopStart()
    {
        ToastPopUpManager.toastmanager.popUps.Add(this);
    }
    public void Test(float yPos = 50f)
    {
        float maxPos = yPos;
        sequence.Append(popUprect.DOAnchorPosY(maxPos, 2, true)).
            OnComplete(() =>
            {
                Debug.Log("≤®¡¸ «ˆªÛ");
                sequence.Append(popImage.DOFade(1 / 255f, 3));
                sequence.Append(commnetText.DOFade(1 / 255f, 3));
            });
        /*
            .OnComplete(() =>
            {
                Debug.Log("µ•¿Ã≈Õ √ ±‚»≠");
                popImage.color = new Color(1, 1, 1, 1);
                popImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(200, -50);
                commnetText.color = new Color(1, 1, 1, 1);
                Gamemanager.instance.objectPool.ReturnObject(PopType.ToastPopUp, this);
                ToastPopUpManager.toastmanager.popUps.Remove(this);
            }
            )
            .SetAutoKill(false);
        */
    }
}
