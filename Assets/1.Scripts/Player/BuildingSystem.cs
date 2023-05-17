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
        //�ǹ� ����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Q ������ �ű�ٰ� ��ġ ���ϰ� Q������ �ʱ�ȭ
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
        //����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            //Ÿ���� ������
            if (CheckTile(selectedObject))
            {
                selectedObject.Place();
                Vector3Int startpos = gridLayout.WorldToCell(selectedObject.GetStartPosition());
                TakenArea(startpos, selectedObject.Size);

                //��ġ �ϴ� ���� ���� ���� ����
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
        //�� ó�� �����Ҷ� 0,0,0�� ����
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        selectedObject = obj.GetComponent<PlaceableObject>();
        //������ ������Ʈ�� HandlingObject�Ӽ� �߰�
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
        //Ÿ���� ����ִ���
public bool CheckTile(PlaceableObject ob)
    {

        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(ob.GetStartPosition());
        area.size = ob.Size;

        //Ÿ�� ���̽� [Ÿ�� ��������]
        TileBase[] baseArray = GetTileBlock(area, mainTilemap);

        foreach (var b in baseArray)
        {
            //b�� takenTile�� �ִٸ�???
            if (b == takenTile)
            {
                return false;
            }
        }

        return true;
    }
    //Ÿ�� ��ĥ �Լ�
    public void TakenArea(Vector3Int startpos, Vector3Int size)
    {
        mainTilemap.BoxFill(startpos, takenTile,
            startpos.x, startpos.y,
            startpos.x + size.x, startpos.y + size.y);
    }
}
