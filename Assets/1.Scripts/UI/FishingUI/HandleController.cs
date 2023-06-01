using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleController : MonoBehaviour
{
    private BoxCollider2D coll;
    private RectTransform rectTransform;

    private bool isIn = false;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();
        coll.size = rectTransform.rect.size;
    }
    public bool GetIsIn()
    {
        return isIn;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CompletePoint"))
        {
            isIn = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("CompletePoint"))
        {
            isIn = true;
        }
    }
}
