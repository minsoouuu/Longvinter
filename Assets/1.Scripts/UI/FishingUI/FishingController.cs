using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    [SerializeField] private RectTransform comPletePoint;
    [SerializeField] private HandleController handle;
    [SerializeField] private RectTransform handleRT;
    [SerializeField] private RectTransform backRT;

    private float handleSpeed = 100f;

    bool isTurn = true;
    Vector2 maxPos;
    private void Awake()
    {
        handleRT = handle.GetComponent<RectTransform>();
        maxPos = new Vector2(backRT.rect.xMax * 2, backRT.rect.yMax * 2);
    }
    private void Update()
    {
        if (isTurn)
        {
            if (handleRT.anchoredPosition.x * 0.5f <= maxPos.x)
            {
                handleRT.pivot = new Vector2(1, 0.5f);
                handleRT.localPosition += Vector3.right * Time.deltaTime * handleSpeed;
            }
            else
            {
                isTurn = false;
            }
        }
        else
        {
            handleRT.localPosition += Vector3.left * Time.deltaTime * handleSpeed;
            if (handleRT.anchoredPosition.x <= 15)
            {
                isTurn = true;
            }
        }
        if (handle.GetIsIn())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("¼º°ø");
            }
        }
    }
}
