using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingObject : MonoBehaviour
{
    Vector3 offset;

    private void Start()
    {
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(BuildingSystem.b_instance.selectedObject.GetStartPosition());
        BuildingSystem.b_instance.DeleteArea();
        BuildingSystem.b_instance.TakenArea(startpos, BuildingSystem.b_instance.selectedObject.Size);
    }
    private void OnMouseDown()
    {
        offset = transform.position - ClickObject();
    }

    // 마우스 드래그로 오브젝트 움직이기
    private void OnMouseDrag()
    {
        Vector3 pos = ClickObject() + offset;

        transform.position = BuildingSystem.b_instance.SnapCoordinateToGrid(pos);
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(BuildingSystem.b_instance.selectedObject.GetStartPosition());
        BuildingSystem.b_instance.DeleteArea();
        BuildingSystem.b_instance.TakenArea(startpos, BuildingSystem.b_instance.selectedObject.Size);
    }

    // 마우스 클릭
    private Vector3 ClickObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            BoxCollider boxCollider = hit.collider as BoxCollider;
            if(boxCollider != null)
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }
}
