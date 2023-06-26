using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HandlingObject : MonoBehaviour
{
    public enum PlantKind
    {
        House,
        Fence,
        Shelf
    }
    Vector3 offset;
    public bool PlacedH { get; private set; }
    bool isDelete;
    public PlantKind pk;
    
    private void Start()
    {
        isDelete = false;
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(BuildingSystem.b_instance.selectedObject.GetStartPosition());
        BuildingSystem.b_instance.TakenArea(startpos, BuildingSystem.b_instance.selectedObject.Size);
    }

    private void Update()
    {
        if (isDelete == true)
        {
            if (Gamemanager.instance.interUI.text.text.Equals("삭제"))
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    Destroy(this.gameObject);
                    Gamemanager.instance.interUI.IsOn = false;
                    Gamemanager.instance.interUI.DeleteUI();
                }
            }
            if (Input.GetKey(KeyCode.T))
            {
                isDelete = false;
                Gamemanager.instance.interUI.IsOn = false;
                Gamemanager.instance.interUI.DeleteUI();
            }
        }
    }
    public void SetPlaced()
    {
        PlacedH = true;
    }
    
    private void OnMouseDown()
    {
        if (PlacedH)
        {
            Gamemanager.instance.interUI.IsOn = true;
            Gamemanager.instance.interUI.SetUi("Z", "삭제");

            isDelete = true;
        }
        else
        {
            offset = transform.position - ClickObject();
        }
    }
    
    
    
    // 마우스 드래그로 오브젝트 움직이기
    private void OnMouseDrag()
    {
        BoundsInt area = new BoundsInt();
        TileBase[] baseArray = BuildingSystem.b_instance.GetTileBlock(area, BuildingSystem.b_instance.mainTilemap);
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        
        BuildingSystem.b_instance.DeleteArea();
        if (!PlacedH)
        {
            Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(BuildingSystem.b_instance.selectedObject.GetStartPosition());
            Vector3 pos = ClickObject() + offset;
            transform.position = BuildingSystem.b_instance.SnapCoordinateToGrid(pos);
            BuildingSystem.b_instance.TakenArea(startpos, BuildingSystem.b_instance.selectedObject.Size);
        }
        else
        {
            return;
        }
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
