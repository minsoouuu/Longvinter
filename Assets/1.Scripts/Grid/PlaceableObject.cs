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


    // 오브젝트 설치
    public void Place()
    {
        HandlingObject drag = gameObject.GetComponent<HandlingObject>();
        //Destroy(drag);
        Placed = true;
    }

    //위치를 Vertex에 넣는 함수
    public void VertexLocalPosition()
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        vertices = new Vector3[4];
        //정육면체 아래 면의 사각형의 포지션
        vertices[0] = box.center + new Vector3(-box.size.x, -box.size.y, -box.size.z) * 0.5f;
        vertices[1] = box.center + new Vector3(-box.size.x, -box.size.y, box.size.z) * 0.5f;
        vertices[2] = box.center + new Vector3(box.size.x, -box.size.y, box.size.z) * 0.5f;
        vertices[3] = box.center + new Vector3(box.size.x, -box.size.y, -box.size.z) * 0.5f;
    }

    //Vertex를 계산해서 타일 사이즈 측정
    public void CalculateTileSize()
    {
        Vector3Int[] verticesInt = new Vector3Int[vertices.Length];

        for (int i = 0; i < verticesInt.Length; i++)
        {
            Vector3 worldpos = transform.TransformPoint(vertices[i]);
            
            //타일맵 기준
            verticesInt[i] = BuildingSystem.b_instance.gridLayout.WorldToCell(worldpos);
        }

        int x = Mathf.Abs((verticesInt[0] - verticesInt[2]).x);
        int y = Mathf.Abs((verticesInt[1] - verticesInt[3]).y); //?
        Size = new Vector3Int(x + 1, y + 1, 1);
    }

    // 색칠할 Cell 시작 포지션 설정
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    public void Rotate()
    {
        //기존 회전값에 행렬을 곱함
        transform.Rotate(new Vector3(0, 270, 0));
        //90도 회전이라 x는 y, y는 x로 바뀜
        Size = new Vector3Int(Size.y, Size.x, Size.z);

        Vector3[] changeVertices = new Vector3[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            //vertices값을 한칸식 올림
            changeVertices[i] = vertices[(i + 1) % vertices.Length];
        }

        vertices = changeVertices;
        transform.GetChild(1).transform.Rotate(new Vector3(0, 90, 0));
    }
    

    public void OnDestroy()
    {
        Vector3Int startpos = BuildingSystem.b_instance.gridLayout.WorldToCell(this.GetStartPosition());

        int rand = Random.Range(0, 4);
        // 타일 색칠하기
        BuildingSystem.b_instance.PlantArea(startpos, this.Size, BuildingSystem.b_instance.originalTile[rand]);
    }
}
