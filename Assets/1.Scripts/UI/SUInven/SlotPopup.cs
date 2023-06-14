using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPopup : MonoBehaviour
{
    Item item = null;
    void Start()
    {
        Enable(false);
    }

    /// <summary>
    /// 팝업 끄고 켜기
    /// </summary>
    public void Enable(bool isShow,Item item = null)
    {
        gameObject.SetActive(isShow);
        if (isShow)
        {
            this.item = item;
        }
        else
        {
            item = null;
        }
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
