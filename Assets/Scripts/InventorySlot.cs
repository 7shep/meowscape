using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;  // Assign this in the inspector
    public Text itemName; // Assign this if you have a text element

    public void AddItem(Item newItem)
    {
        icon.sprite = newItem.icon;
        icon.enabled = true;
        if (itemName != null)
            itemName.text = newItem.itemName;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        if (itemName != null)
            itemName.text = "";
    }
}
