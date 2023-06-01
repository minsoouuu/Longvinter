using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
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
                makeController.items.Add(ItemData);
            }
            else
            {
                itemIcon.sprite = nullSprite;
                if (makeController.items.Contains(ItemData))
                {
                    makeController.items.Remove(ItemData);
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
        Debug.Log("Å¬¸¯");
        if (ItemData == null)
            return;
        ItemData = null;
    }
}
