using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    public RectTransform rt;
    private CanvasScaler canvasScaler;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        TryGetComponent(out rt);
        rt.pivot = new Vector2(0f, 1f); // Left Top
        canvasScaler = GetComponentInParent<CanvasScaler>();

        DisableAllChildrenRaycastTarget(transform);
    }

    private void DisableAllChildrenRaycastTarget(Transform tr)
    {
        // ?????? Graphic(UI)?? ???????? ?????????? ???? ????
        tr.TryGetComponent(out Graphic gr);
        if (gr != null)
            gr.raycastTarget = false;

        // ???? ?????? ????
        int childCount = tr.childCount;
        if (childCount == 0) return;

        for (int i = 0; i < childCount; i++)
        {
            DisableAllChildrenRaycastTarget(tr.GetChild(i));
        }
    }

    public void SetRectPosition(RectTransform slotRect)
    {
        // ?????? ?????????? ???? ?????? ????
        float wRatio = Screen.width / canvasScaler.referenceResolution.x;
        float hRatio = Screen.height / canvasScaler.referenceResolution.y;
        float ratio =
            wRatio * (1f - canvasScaler.matchWidthOrHeight) +
            hRatio * (canvasScaler.matchWidthOrHeight);

        float slotWidth = slotRect.rect.width * ratio;
        float slotHeight = slotRect.rect.height * ratio;

        rt.position = slotRect.position + new Vector3(slotWidth, -slotHeight);
    }
}
