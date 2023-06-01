using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enable(false);
    }

    /// <summary>
    /// 팝업 끄고 켜기
    /// </summary>
    public void Enable(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    /// <summary>
    /// 버리기
    /// </summary>
    public void OnDrop()
    {

    }

    /// <summary>
    /// 사용하기
    /// </summary>
    public void OnUse()
    {

    }
}
