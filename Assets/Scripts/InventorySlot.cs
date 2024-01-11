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
        //itemName.text = newItem.itemName; // Assuming itemName is a Text or TMPro.TextMeshProUGUI component.
    }


    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        //itemName.text = "";
    }

}
