using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;

    void OnMouseDown()
    {
        offset = transform.position - BuildSystem.GetMouseWorldPositoin();
    }

    private void OnMouseDrag()
    {
        Vector3 pos = BuildSystem.GetMouseWorldPositoin() + offset;
        transform.position = BuildSystem.current.SnapCoordinateToGrid(pos);

    }

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = BuildSystem.current.SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        BuildSystem.current.objecttoPlace = obj.gameObject.GetComponent<Placeable>();
        obj.gameObject.AddComponent<ObjectDrag>();
    }
}
