using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;

    public GridLayout gridLayout;
    public Grid grid;
    public Tilemap mainTilemap;
    public TileBase takenTile;

    public GameObject prefab1;
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
            InitWithObject(prefab1);
        }
    }
    public void InitWithObject(GameObject building)
    {
        //�� ó�� �����Ҷ� 0,0,0�� ����
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        //������ ������Ʈ�� HandlingObject�Ӽ� �߰�
        obj.AddComponent<HandlingObject>();
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }
}
