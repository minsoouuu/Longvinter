using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketController : MonoBehaviour
{
    [SerializeField] private List<PocketSlot> pocketSlots;
    [SerializeField] private Button escButton;

    public void AddItem(Item item)
    {
        for (int i = 0; i < pocketSlots.Count; i++)
        {
            if (pocketSlots[i].Item == null)
            {
                pocketSlots[i].Item = item;
                break;
            }
        }
    }
}
