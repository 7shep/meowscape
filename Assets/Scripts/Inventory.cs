using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // Singleton instance
    public static Inventory instance;

    // This is the GameObject that represents the panel in your UI where the inventory items will be shown.
    // You need to assign this in the Unity Inspector.
    [SerializeField] private GameObject inventoryPanel;

    // This list will hold the actual item data for your inventory.
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    // Update the inventory UI by adding/removing items
    private void UpdateInventoryUI()
    {
        // Assuming you have 16 slots, 4x4 in your UI panel
        for (int i = 0; i < 16; i++)
        {
            // Find the specific slot in the UI
            Transform slotTransform = inventoryPanel.transform.GetChild(i);
            Image image = slotTransform.GetComponentInChildren<Image>(true);
            Text text = slotTransform.GetComponentInChildren<Text>(true);

            // If there's an item at this slot index, update the UI accordingly
            if (i < items.Count)
            {
                image.sprite = items[i].icon;
                image.enabled = true; // Enable the image component if it's disabled
                text.text = items[i].itemName;
            }
            else
            {
                // If there's no item, disable the image component and clear the text
                image.enabled = false;
                text.text = "";
            }
        }
    }

    // Call this method to add an item to the inventory
    public bool Add(Item item)
    {
        if (items.Count >= 16) // Assuming 16 slots in total
        {
            Debug.Log("Not enough room in inventory.");
            return false;
        }

        items.Add(item);
        UpdateInventoryUI();
        return true;
    }

    // Call this method to remove an item from the inventory
    public void Remove(Item item)
    {
        items.Remove(item);
        UpdateInventoryUI();
    }
}
