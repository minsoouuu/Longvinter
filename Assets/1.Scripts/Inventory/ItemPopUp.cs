using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{

    [SerializeField] private GameObject popup;
    [SerializeField] private Transform parent;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        HideToolTip();
    }
    public void ShowToolTip(Vector2 pos)
    {
        pos.x -= 170;
        pos.y += 275;
        rt.anchoredPosition = pos;
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

}
