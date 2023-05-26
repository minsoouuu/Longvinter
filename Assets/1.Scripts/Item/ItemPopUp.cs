using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{

    [SerializeField] public GameObject popup;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        HideTool(rt.anchoredPosition);
    }
    public void ShowTool(Vector2 pos)
    {
        pos.x -= 170;
        pos.y += 275;
        rt.anchoredPosition = pos;
        gameObject.SetActive(true);

    }

    public void HideTool(Vector2 pos)
    {
        gameObject.SetActive(false);
        rt.anchoredPosition = pos;
    }

}
