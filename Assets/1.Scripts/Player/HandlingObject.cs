using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandlingObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - ClickObject();
    }
    private void OnMouseDrag()
    {
        Vector3 vec = new Vector3(ClickObject().x, 0, ClickObject().z);
        //���콺�� ���� �����ǰ�[ȭ��] ����
        Vector3 pos = ClickObject() + offset;
        //ȭ�� ������ ���� Ÿ�ϸ� ��ǥ�� ��ȯ
        transform.position = BuildingSystem.instance.SnapCoordinateToGrid(pos);

    }
    //Ŭ���� ������Ʈ�� ������ �� ���
    private Vector3 ClickObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            BoxCollider boxCollider = hit.collider as BoxCollider;
            if (boxCollider != null)
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }
}
