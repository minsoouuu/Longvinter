using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    Image image;
    [HideInInspector] public Item item;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetItemData(Item item)
    {
        image.sprite = item.data.itemImage;
        countText.text = item.Count.ToString();
        this.item = item;
    }

    public void DeleteItem()
    {
        this.item = null;
        item.Count--;
        if (item.Count == 0)
        {
            image.sprite = Resources.Load<Sprite>("HONETi/mobile_cartoon_GUI/GUI Elements/Textfield/text_background_big");
        }

    }
}
