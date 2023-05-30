using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakeController makeController;
    [SerializeField] private Sprite nullSprite;
    private Image itemIcon;
    public bool IsCheck { get; set; }

    public Item ItemData
    {
        get { return ItemData; }
        set
        {
            ItemData = value;
            if (ItemData != null)
            {
                itemIcon.sprite = value.data.image;
                //makeController.makingSlots.Add(this);
            }
            else
            {
                itemIcon.sprite = nullSprite;
               // makeController.makingSlots.Remove(this);
            }
        }
    }

    void Awake()
    {
        itemIcon = GetComponent<Image>();
        IsCheck = true;
    }
    public Item GetItemData()
    {
        return ItemData;
    }
    public void DeleteItemData()
    {
        ItemData = null;
    }
}
