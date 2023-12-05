using UnityEngine;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>(); // Assuming Inventory is attached to the same GameObject
        //inventory.onItemChangedCallback += UpdateUI;
    }

    void Update()
    {
        // Your update logic (if any)
    }

    void UpdateUI()
    {
        Debug.Log("Inventory Updated");
        // Update your UI here based on the inventory changes
    }
}
