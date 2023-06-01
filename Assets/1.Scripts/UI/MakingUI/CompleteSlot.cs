using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteSlot : MonoBehaviour
{
    [SerializeField] private MakingController mController;
    [SerializeField] private Image itemImage;
    [SerializeField] private Sprite nullImage;

    private Item item;
    public Item ItemData
    {
        get { return item; }
        set
        {
            item = value;
            if (ItemData != null)
            {
                itemImage.sprite = ItemData.data.image;
            }
            else
            {
                itemImage.sprite = nullImage;
            }
        }
    }
    private void Awake()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }
}
