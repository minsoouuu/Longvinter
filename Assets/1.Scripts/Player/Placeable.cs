using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public bool Placed { get; private set; }

    public Vector3Int Size { get; private set; }

    Vector3[] vertices;

    private void Start()
    {
        GetColliderVertexPositionsLocal();
        CalculateSizeInCells();
    }
    void GetColliderVertexPositionsLocal()
    {
        BoxCollider b = GetComponent<BoxCollider>();
        vertices = new Vector3[4];
        vertices[0] = new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
        vertices[1] = new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        vertices[2] = new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        vertices[3] = new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
    }

    void CalculateSizeInCells()
    {
        Vector3Int[] vertices_ = new Vector3Int[vertices.Length];

        for (int i = 0; i < vertices_.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(vertices[i]);
            vertices_[i] = BuildSystem.current.gridLayout.WorldToCell(worldPos);
        }

        Size = new Vector3Int(Mathf.Abs((vertices_[0] - vertices_[1]).x),
                              Mathf.Abs((vertices_[0] - vertices_[3]).y), 1);
    }
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    public virtual void Place()
    {

        ObjectDrag drag = GetComponent<ObjectDrag>();
        Destroy(drag);

        Placed = true;
    }
}
