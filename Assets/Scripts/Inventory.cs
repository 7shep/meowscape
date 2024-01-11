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
    // Update the inventory UI by adding/removing items
    private void UpdateInventoryUI()
    {
        Debug.Log("Updating Inventory UI");

        int childCount = inventoryPanel.transform.childCount; // Get the actual number of children

        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            InventorySlot slot = inventoryPanel.transform.GetChild(i).GetComponent<InventorySlot>();
            if (i < items.Count)
            {
                slot.AddItem(items[i]);
            }
            else
            {
                slot.ClearSlot();
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

        Debug.Log($"Adding item: {item.itemName}");
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
