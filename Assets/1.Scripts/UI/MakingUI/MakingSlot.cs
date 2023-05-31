using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakingController makeController;
    [SerializeField] private Sprite nullSprite;
    private Image itemIcon;
    private Item item = null;
    public Item ItemData
    {
        get { return item; }
        set
        {
            item = value;
            Debug.Log($"{gameObject.name}:{value}");
            if (item != null)
            {
                itemIcon.sprite = value.data.image;
                makeController.items.Add(ItemData);
                Debug.Log("������ �̹��� ��ȯ");
            }
            else
            {
                itemIcon.sprite = nullSprite;
                makeController.items.Remove(ItemData);
                Debug.Log("�ʱ�ȭ");
            }
            Debug.Log(makeController.items.Count);
        }
    }
    void Awake()
    {
        itemIcon = transform.GetChild(0).GetComponent<Image>();
    }
}
