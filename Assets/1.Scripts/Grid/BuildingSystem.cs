using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem b_instance;

    public GridLayout gridLayout;
    public Grid grid;
    public Tilemap mainTilemap;
    public TileBase takenTile;

    public HandlingObject prefab;
    PlaceableObject selectedObject;


    static TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int count = 0;

        foreach (var item in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(item.x, item.y, 0);
            array[count] = tilemap.GetTile(pos);
            count++;
        }
        return array;
    }
    private void Awake()
    {
        b_instance = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(selectedObject != null)
            {
                Destroy(selectedObject.gameObject);
                selectedObject = null;
            }
            InitWithObject(prefab);
            Debug.Log(selectedObject);
        }

        if (!selectedObject)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckTile(selectedObject))
            {
                selectedObject.Place();
                Vector3Int startpos = gridLayout.WorldToCell(selectedObject.GetStartPosition());
                TakenArea(startpos, selectedObject.Size);

                Destroy(selectedObject.gameObject.GetComponent<HandlingObject>());
                selectedObject = null;
            }
            else
            {
                Destroy(selectedObject.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(selectedObject.gameObject);
        }
    }

    public void InitWithObject(HandlingObject building)
    {
        Vector3 pos = SnapCoordinateToGrid(Vector3.zero);

        HandlingObject obj = Instantiate(building, pos, Quaternion.identity) as HandlingObject;
        selectedObject = obj.GetComponent<PlaceableObject>();
        
    }

    public Vector3 SnapCoordinateToGrid(Vector3 pos)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(pos);
        pos = grid.GetCellCenterWorld(cellPos);
        return pos;
    }

    public bool CheckTile(PlaceableObject ob)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(ob.GetStartPosition());
        area.size = ob.Size;

        TileBase[] baseArray = GetTileBlock(area, mainTilemap);

        foreach (var b in baseArray)
        {
            //b에 takenTile가 있다면???
            if (b == takenTile)
            {
                return false;
            }
        }
        return true;
    }

    public void TakenArea(Vector3Int startpos, Vector3Int size)
    {
        mainTilemap.BoxFill(startpos, takenTile, startpos.x, startpos.y, startpos.x + size.x, startpos.y + size.y);
    }
}
