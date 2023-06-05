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
    public TileBase resultTile;
    public User player;
    public TreeScript tree;

    public HandlingObject prefab;
    [HideInInspector] public PlaceableObject selectedObject;


    // 타일맵 생성
    public TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int count = 0;

        foreach (var item in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(item.x, item.y, 0);
            Debug.Log(pos);
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
        player = player.GetComponent<User>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Create_prefab();
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

                // 타일 미리보기
                TakenArea(startpos, selectedObject.Size);

                // 타일 색칠하기
                PlantArea(startpos, selectedObject.Size);
                DeleteArea();
                Destroy(selectedObject.gameObject.GetComponent<HandlingObject>());
                selectedObject = null;
            }
            else
            {
                Debug.Log("겹친다");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(selectedObject.gameObject);
        }
    }

    // Prefab 생성
    public void InitWithObject(HandlingObject building)
    {
        Vector3 playerpos = new Vector3(player.transform.position.x, 0, player.transform.position.z + 2f);
        Vector3 pos = SnapCoordinateToGrid(playerpos);

        HandlingObject obj = Instantiate(building, pos, Quaternion.identity);
        selectedObject = obj.GetComponent<PlaceableObject>();
    }


    // Cell좌표로 포지션 변경
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
        // Debug.Log(area.position);
        area.size = ob.Size;
        //Debug.Log(area.size);

        TileBase[] baseArray = GetTileBlock(area, mainTilemap);
        foreach (var b in baseArray)
        {
            //b에 takenTile가 있다면???
            if (b == resultTile)
            {
                return false;
            }
        }
        return true;
    }

    // 타일 미리보기
    public void TakenArea(Vector3Int startpos, Vector3Int size)
    {
        mainTilemap.EditorPreviewBoxFill(startpos, takenTile, startpos.x, startpos.y, startpos.x + (size.x - 1), startpos.y + (size.y - 1));
    }

    // 타일 색칠하기
    public void PlantArea(Vector3Int startpos, Vector3Int size)
    {
        mainTilemap.BoxFill(startpos, resultTile, startpos.x, startpos.y, startpos.x + (size.x - 1), startpos.y + (size.y - 1));
    }

    // 미리보기 타일 지우기
    public void DeleteArea()
    {
        mainTilemap.ClearAllEditorPreviewTiles();
    }


    public void Create_prefab()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject.gameObject);
            selectedObject = null;
        }
        InitWithObject(prefab);
    }
}
