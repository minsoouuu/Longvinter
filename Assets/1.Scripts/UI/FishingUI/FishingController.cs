using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    [SerializeField] private RectTransform comPletePoint;
    [SerializeField] private HandleController handle;
    [SerializeField] private RectTransform handleRT;

    private float handleSpeed = 50f;

    bool isTurn = true;
    private void Awake()
    {
        handleRT = handle.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isTurn)
        {
            if (handleRT.anchoredPosition.x <= 470)
            {
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
