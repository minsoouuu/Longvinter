using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public Vector3Int Size { get; private set; }
    private Vector3[] vertices;
    // Start is called before the first frame update
    private void Start()
    {
        VertexLocalPosition();
        CalculateTileSize();
        //DeleteTile();
    }
    
    public void VertexLocalPosition()
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        vertices = new Vector3[4];
        //������ü �Ʒ� ���� �簢���� ������
        vertices[0] = box.center + new Vector3(-box.size.x, -box.size.y, -box.size.z) * 0.5f;
        vertices[1] = box.center + new Vector3(-box.size.x, -box.size.y, box.size.z) * 0.5f;
        vertices[2] = box.center + new Vector3(box.size.x, -box.size.y, box.size.z) * 0.5f;
        vertices[3] = box.center + new Vector3(box.size.x, -box.size.y, -box.size.z) * 0.5f;
    }

    //Vertex�� ����ؼ� Ÿ�� ������ ����
    private void CalculateTileSize()
    {
        Vector3Int[] verticesInt = new Vector3Int[vertices.Length];

        for (int i = 0; i < verticesInt.Length; i++)
        {
            Vector3 worldpos = transform.TransformPoint(vertices[i]);
            //Debug.Log(worldpos);
            //Ÿ�ϸ� ����
            verticesInt[i] = BuildingSystem.b_instance.gridLayout.WorldToCell(worldpos);
            //Debug.Log(verticesInt[i]);
        }

        int x = Mathf.Abs((verticesInt[0] - verticesInt[2]).x);
        //Debug.Log(x);
        int y = Mathf.Abs((verticesInt[1] - verticesInt[3]).y); //?
        Size = new Vector3Int(x + 1, y + 1, 1);
        //Debug.Log(Size);
    }

    // ��ĥ�� Cell ���� ������ ����
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }
    /*
    public void OnDestroy()
    {
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());

        // Ÿ�� ��ĥ�ϱ�
        BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile);
    }
    
    
    public void OnDisable()
    {
        Debug.Log("enable");    
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());
        // Ÿ�� ��ĥ�ϱ�
        BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile);
    }
    
    public void DeleteTile()
    {
        if (!this.enabled)
        {
            Debug.Log("enable");
            Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());

            // Ÿ�� ��ĥ�ϱ�
            BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile);
        }
    }
    
    public void OnEnable()
    {
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());

        // Ÿ�� ��ĥ�ϱ�
        BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile);
    }
    */
}
