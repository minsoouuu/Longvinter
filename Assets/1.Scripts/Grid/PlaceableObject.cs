using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; }
    public Vector3Int Size { get; private set; }
    private Vector3[] vertices;
    
    private void Awake()
    {
        VertexLocalPosition();
        CalculateTileSize();
    }


    // ������Ʈ ��ġ
    public void Place()
    {
        HandlingObject drag = gameObject.GetComponent<HandlingObject>();
        //Destroy(drag);
        Placed = true;
    }

    //��ġ�� Vertex�� �ִ� �Լ�
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
    public void CalculateTileSize()
    {
        Vector3Int[] verticesInt = new Vector3Int[vertices.Length];

        for (int i = 0; i < verticesInt.Length; i++)
        {
            Vector3 worldpos = transform.TransformPoint(vertices[i]);
            
            //Ÿ�ϸ� ����
            verticesInt[i] = BuildingSystem.b_instance.gridLayout.WorldToCell(worldpos);
        }

        int x = Mathf.Abs((verticesInt[0] - verticesInt[2]).x);
        int y = Mathf.Abs((verticesInt[1] - verticesInt[3]).y); //?
        Size = new Vector3Int(x + 1, y + 1, 1);
    }

    // ��ĥ�� Cell ���� ������ ����
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    public void Rotate()
    {
        //���� ȸ������ ����� ����
        transform.Rotate(new Vector3(0, 270, 0));
        //90�� ȸ���̶� x�� y, y�� x�� �ٲ�
        Size = new Vector3Int(Size.y, Size.x, Size.z);

        Vector3[] changeVertices = new Vector3[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            //vertices���� ��ĭ�� �ø�
            changeVertices[i] = vertices[(i + 1) % vertices.Length];
        }

        vertices = changeVertices;
        transform.GetChild(1).transform.Rotate(new Vector3(0, 90, 0));
    }
    

    public void OnDestroy()
    {
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());

        int rand = Random.Range(0, 4);
        // Ÿ�� ��ĥ�ϱ�
        BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile[rand]);
    }
}
