using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button button;
    private Sprite nullSprite;
    private Item item = null;
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (Item != null)
            {
                icon.sprite = Item.data.image;
                Debug.Log($"{gameObject.name}:{Item.data.itemName}");
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
        button.onClick.AddListener(() => OnButtonDown());
    }
    public void SetData(Item item)
    {
        Item = item;
        icon.sprite = Item.data.image;
        Debug.Log($"{gameObject.name}:{Item.data.itemName}");
    }
    public void DeleteData()
    {
        Item = null;
        icon.sprite = nullSprite;
    }
    public void OnButtonDown()
    {
        if (Item == null)
            return;

        AudioManager.instance.audio.Play();
        Gamemanager.instance.player.im.ADItem(Item, true);

        if (Gamemanager.instance.player.im.CheckEmpty(Item))
        {
            Item = null;
        }
    }
}
