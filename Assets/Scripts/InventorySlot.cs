using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    InventorySlot item;

    public void AddItem(InventorySlot newItem)
    {
        item = newItem;


        icon.sprite = newItem.icon.sprite; 
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
