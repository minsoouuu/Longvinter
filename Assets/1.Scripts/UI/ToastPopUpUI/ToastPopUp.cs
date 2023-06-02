using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToastPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text commnetText;

    private List<IEnumerator> popUps = new List<IEnumerator>();
    private RectTransform popUprect;
    private string comment;
    private float popUpMoveSpeed = 10f;
    public string Comment
    {
        get { return comment; }
        set
        {
            comment = value;
            commnetText.text = Comment;
        }
    }
    private void Awake()
    {
        popUprect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        StartCoroutine("PopUpMove");

        if (popUps.Count > 1)
        {
            foreach (IEnumerator pop in popUps)
            {

            }
        }
    }
    IEnumerator PopUpMove()
    {
        while (true)
        {
            if (popUprect.anchoredPosition.y >= 100)
            {
                yield break;
            }
            popUprect.anchoredPosition += Vector2.up * popUpMoveSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
