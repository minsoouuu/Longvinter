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
    /// �˾� ���� �ѱ�
    /// </summary>
    public void Enable(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    /// <summary>
    /// ������
    /// </summary>
    public void OnDrop()
    {

    }

    /// <summary>
    /// ����ϱ�
    /// </summary>
    public void OnUse()
    {

    }
}
