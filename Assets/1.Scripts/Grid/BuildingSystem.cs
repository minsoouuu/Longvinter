using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem b_instance;

    public GridLayout gridLayout;
    public Grid grid;
    public Tilemap mainTilemap;
    public TileBase takenTile;
    public TileBase resultTile;
    public TileBase originalTile;
    public List<MaterialScript> tree_rock;

    public HandlingObject[] prefab;
    public Transform houseparent;
    public Transform fenceparent;
    [HideInInspector] public PlaceableObject selectedObject;
    List<PlaceableObject> prefab_list = new List<PlaceableObject>();

    // 타일맵 생성
    public TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
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
        PlantTree();
    }

    // Update is called once per frame
    void Update()
    {

        if (!selectedObject)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckTile(selectedObject))
            {
                selectedObject.Place();
                selectedObject.GetComponent<HandlingObject>().SetPlaced();
                Vector3Int startpos = gridLayout.WorldToCell(selectedObject.GetStartPosition());

                // 타일 미리보기
                TakenArea(startpos, selectedObject.Size);

                // 타일 색칠하기
                PlantArea(startpos, selectedObject.Size, resultTile);
                //Destroy(selectedObject.gameObject.GetComponent<HandlingObject>());
                selectedObject = null;

                GenerateNavmesh();
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedObject.Rotate();
        }
    }

    // Prefab 생성
    public void InitWithObject(HandlingObject building)
    {
        Vector3 playerpos = new Vector3(Gamemanager.instance.player.transform.position.x, 0, Gamemanager.instance.player.transform.position.z + 2f);
        Vector3 pos = SnapCoordinateToGrid(playerpos);

        HandlingObject obj = Instantiate(building, pos, Quaternion.identity);
        if(obj.pk == HandlingObject.PlantKind.House)
        {
            obj.transform.SetParent(houseparent);
        }
        else if(obj.pk == HandlingObject.PlantKind.Fence)
        {
            obj.transform.SetParent(fenceparent);
        }
        selectedObject = obj.GetComponent<PlaceableObject>();
        prefab_list.Add(selectedObject);
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
        mainTilemap.BoxFill(startpos, takenTile, startpos.x, startpos.y, startpos.x + (size.x - 1), startpos.y + (size.y - 1));
    }

    // 타일 색칠하기
    public void PlantArea(Vector3Int startpos, Vector3Int size, TileBase tilebase)
    {
        mainTilemap.BoxFill(startpos, tilebase, startpos.x, startpos.y, startpos.x + (size.x - 1), startpos.y + (size.y - 1));
    }


    // 미리보기 타일 지우기
    public void DeleteArea()
    {
        mainTilemap.SwapTile(takenTile, originalTile);
    }




    public void Create_prefab(string name)
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject.gameObject);
            selectedObject = null;
        }
        switch (name)
        {
            case "FenceGate":
                InitWithObject(prefab[0]);
                break;
            case "Tent":
                InitWithObject(prefab[1]);
                break;
            case "Bench":
                InitWithObject(prefab[2]);
                break;
        }
    }

    public void PlantTree()
    {
        if(tree_rock.Count == 0)
        {
            return;
        }
        foreach (var item in tree_rock)
        {
            Vector3Int startpos = gridLayout.WorldToCell(item.GetStartPosition());
            PlantArea(startpos, item.Size, resultTile);
        }
    }

    public void ClearTile()
    {
        foreach (var item in tree_rock)
        {
            if (!item.enabled)
            {
                Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(item.GetStartPosition());
                // 타일 색칠하기
                BuildingSystem.b_instance.PlantArea(startpos, item.Size, BuildingSystem.b_instance.originalTile);
            }
        }
    }

    private void GenerateNavmesh()
    {
        NavMeshSurface[] surfaces = gameObject.GetComponentsInChildren<NavMeshSurface>();

        foreach (var s in surfaces)
        {
            s.RemoveData();
            s.BuildNavMesh();
        }

    }
}
