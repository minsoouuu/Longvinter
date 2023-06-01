using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; }
    public Vector3Int Size { get; private set; }
    private Vector3[] vertices;
    
    private void Start()
    {
        VertexLocalPosition();
        CalculateTileSize();
    }

    public virtual void Preview()
    {
        HandlingObject drag = gameObject.GetComponent<HandlingObject>();
        VertexLocalPosition();
        Placed = false;
    }
    public virtual void Place()
    {
        HandlingObject drag = gameObject.GetComponent<HandlingObject>();
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
    private void CalculateTileSize()
    {
        Vector3Int[] verticesInt = new Vector3Int[vertices.Length];

        for (int i = 0; i < verticesInt.Length; i++)
        {
            Vector3 worldpos = transform.TransformPoint(vertices[i]);
            //Debug.Log(worldpos);
            //타일맵 기준
            verticesInt[i] = BuildingSystem.b_instance.gridLayout.WorldToCell(worldpos);
            //Debug.Log(verticesInt[i]);
        }

        int x = Mathf.Abs((verticesInt[0] - verticesInt[2]).x);
        //Debug.Log(x);
        int y = Mathf.Abs((verticesInt[1] - verticesInt[3]).y); //?
        Size = new Vector3Int(x + 1, y + 1, 1);
        //Debug.Log(Size);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }
}
