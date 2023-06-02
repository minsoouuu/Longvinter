using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ToastPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text commnetText;

    private Transform popUprect;
    private string comment;
    private float popUpMoveSpeed = 10f;
    public string Comment
    {
        get { return comment; }
        set
        {
            comment = value;
            commnetText.text = $"{value} È¹µæ ! ";
        }
    }
    private void Awake()
    {
        popUprect = transform.GetChild(0).GetComponent<Transform>();
    }

    public void ToastPopStart()
    {
        ToastPopUpManager.toastmanager.co = StartCoroutine(PopUpMove());
    }
    IEnumerator PopUpMove()
    {
        Sequence sequence = DOTween.Sequence();
        if (popUprect.position.y == 50)
        {
            Debug.Log("³»·Á°¡");
            yield return new WaitForSeconds(2f);
            StartCoroutine(PopDownMove());
            yield break;
        }
        sequence.Append(popUprect.DOMoveY(50, 2, true));
        //popUprect.position += Vector3.up * popUpMoveSpeed;
    }
    IEnumerator PopDownMove()
    {
        Sequence sequence = DOTween.Sequence();
        if (popUprect.position.y == -50)
        {
            Gamemanager.instance.objectPool.ReturnObject(PopType.ToastPopUp, this);
            ToastPopUpManager.toastmanager.co = null;
            yield break;
        }
        sequence.Append(popUprect.DOMoveY(-50, 2, true));
    }
}
