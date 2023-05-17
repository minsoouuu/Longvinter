using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;
    [SerializeField] private PlaceableObject selectedObject;

    public GridLayout gridLayout;
    [HideInInspector] public Grid grid;
    public Tilemap mainTilemap;
    public TileBase takenTile;

    public GameObject prefab1;

    House house;
    private void Awake()
    {
        instance = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        //건물 생성
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Q 누른후 옮기다가 배치 안하고 Q누르면 초기화
            if (selectedObject != null)
            {
                Destroy(selectedObject.gameObject);
                selectedObject = null;
            }
            InitWithObject(prefab1);
        }

        if (!selectedObject)
        {
            //return;
        }
        //놓는
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            //타일이 없으면
            if (CheckTile(selectedObject))
            {
                selectedObject.Place();
                Vector3Int startpos = gridLayout.WorldToCell(selectedObject.GetStartPosition());
                TakenArea(startpos, selectedObject.Size);

                //배치 하는 순간 조종 권한 제거
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedObject.Rotate();
        }
    }
    public void InitWithObject(GameObject building)
    {
        //맨 처음 생성할때 0,0,0에 생성
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        selectedObject = obj.GetComponent<PlaceableObject>();
        //생성된 오브젝트에 HandlingObject속성 추가
        //obj.AddComponent<HandlingObject>();
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        position.y = 0f;
        return position;
    }
    private static TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int count = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[count] = tilemap.GetTile(pos);
            count++;
        }

        return array;
    }
        //타일이 비어있는지
public bool CheckTile(PlaceableObject ob)
    {

        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(ob.GetStartPosition());
        area.size = ob.Size;

        //타일 베이스 [타일 가져오기]
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
    //타일 색칠 함수
    public void TakenArea(Vector3Int startpos, Vector3Int size)
    {
        mainTilemap.BoxFill(startpos, takenTile,
            startpos.x, startpos.y,
            startpos.x + size.x, startpos.y + size.y);
    }
}
