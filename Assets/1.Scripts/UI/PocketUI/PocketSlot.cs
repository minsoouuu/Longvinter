using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Sprite nullSprite;
    private Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                icon.sprite = Item.data.image;
            }
            else
            {
                icon.sprite = nullSprite;
            }
        }
    }
    void Start()
    {
        nullSprite = Resources.Load<Sprite>("Longvinter_Icons/Gradient");
    }
}
