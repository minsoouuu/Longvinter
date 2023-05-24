using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    public RectTransform rt;
    public RectTransform SlotRect;
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
        // 본인이 Graphic(UI)를 상속하면 레이캐스트 타겟 해제
        tr.TryGetComponent(out Graphic gr);
        if (gr != null)
            gr.raycastTarget = false;

        // 자식 없으면 종료
        int childCount = tr.childCount;
        if (childCount == 0) return;

        for (int i = 0; i < childCount; i++)
        {
            DisableAllChildrenRaycastTarget(tr.GetChild(i));
        }
    }

    public void SetRectPosition(RectTransform slotRect)
    {
        // 캔버스 스케일러에 따른 해상도 대응
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
