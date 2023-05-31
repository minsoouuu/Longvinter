using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenItemClick : MonoBehaviour
{
    [SerializeField] public GameObject popup;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        HideTool();
    }

    public void ShowTool(Vector2 pos)
    {
        pos.x -= 170;
        pos.y += 275;
        rt.anchoredPosition = pos;
        gameObject.SetActive(true);

    }

    public void HideTool()
    {
        gameObject.SetActive(false);
    }

}
