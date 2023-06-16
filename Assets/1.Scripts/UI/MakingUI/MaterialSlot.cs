using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MaterialSlot : MonoBehaviour
{
    [SerializeField] private MakingController makeController;
    [SerializeField] private Sprite nullSprite;
    [SerializeField] private Button slotButton;


    private Image itemIcon;
    private Item item = null;
    public Item ItemData
    {
        get { return item; }
        set
        {
            item = value;
            if (ItemData != null)
            {
                itemIcon.sprite = item.data.image;
                makeController.items.Add(ItemData.data.itemName);
            }
            else
            {
                itemIcon.sprite = nullSprite;
                if (makeController.items.Contains(ItemData.data.itemName))
                {
                    makeController.items.Remove(ItemData.data.itemName);
                }
            }
        }
    }
    void Awake()
    {
        itemIcon = transform.GetChild(0).GetComponent<Image>();
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(() => OnMouseButtonDown());
        }
    }
    void OnMouseButtonDown()
    {
        if (ItemData == null)
            return;

        //Item materialItem = Gamemanager.instance.itemController.GetItem(ItemData.data.itemName);
        ItemData.data.count = 1;
        Gamemanager.instance.player.im.ADItem(ItemData, true);
        ItemData = null;

        if (makeController.completeSlot.ItemData != null)
        {
            makeController.completeSlot.ItemData = null;
        }
        Debug.Log(makeController.items.Count);
    }
}
