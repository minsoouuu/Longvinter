using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialScript : MonoBehaviour
{
    public enum Kind
    {
        Tree,
        Rock,
        Merchant
    }
    public Vector3Int Size { get; private set; }
    private Vector3[] vertices;
    [SerializeField] private Kind kind;
    [SerializeField] private User user;
    public RespawnController rc;


    // Start is called before the first frame update
    public void Awake()
    {
        VertexLocalPosition();
    }

    public void Start()
    {
        CalculateTileSize();
    }

    public void Update()
    {
        Collecting();
    }

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

    // 색칠할 Cell 시작 포지션 설정
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    public void Collecting()
    {
        if (kind == Kind.Tree)
        {
            float dis = Vector3.Distance(transform.position, user.transform.position);
            if (dis < 2f)
            {
                user.ShowImage();
                if (Input.GetKey(KeyCode.E))
                {
                    user.interactionImage.GetComponent<Image>().fillAmount += Time.deltaTime;
                }
                if (user.interactionImage.GetComponent<Image>().fillAmount >= 1)
                {
                    user.CloseImage();
                    user.interactionImage.GetComponent<Image>().fillAmount = 0;
                    rc.gb.Add(gameObject);
                    rc.respawn_Time = 0f;
                    gameObject.SetActive(false);
                }
            }
        }
        else if(kind == Kind.Rock)
        {
            float dis = Vector3.Distance(transform.position, user.transform.position);
            if (dis < 2f)
            {
                user.ShowImage();
                if (Input.GetKey(KeyCode.E))
                {
                    user.interactionImage.GetComponent<Image>().fillAmount += Time.deltaTime;
                }
                if (user.interactionImage.GetComponent<Image>().fillAmount >= 1)
                {
                    user.CloseImage();
                    user.interactionImage.GetComponent<Image>().fillAmount = 0;
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnDestroy()
    {
        BuildingSystem.b_instance.ClearTile();
        BuildingSystem.b_instance.tree_rock.Remove(this);
    }
}
