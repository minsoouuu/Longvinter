using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BuildSystem : MonoBehaviour
{
    public static BuildSystem current;

    public GridLayout gridLayout;
    Grid grid;

    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase redTile;

    public GameObject prefab1;
    public GameObject prefab2;

    [HideInInspector] public Placeable objecttoPlace;

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<ObjectDrag>().InitializeWithObject(prefab1);
        }

        if (!objecttoPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objecttoPlace))
            {
                objecttoPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objecttoPlace.GetStartPosition());
                TakeArea(start, objecttoPlace.Size);
            }
            else
            {
                Destroy(objecttoPlace.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objecttoPlace.gameObject);
        }
    }
    public static Vector3 GetMouseWorldPositoin()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    static TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, v.z);
        }
        return array;
    }
    bool CanBePlaced(Placeable placeable)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(placeable.GetStartPosition());
        area.size = placeable.Size;

        TileBase[] basearray = GetTileBlock(area, mainTilemap);

        foreach (var v in basearray)
        {
            if (v == redTile)
            {
                return false;
            }
        }
        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        mainTilemap.BoxFill(start, redTile, start.x, start.y, start.x + size.x, start.y + size.y);
    }

}
