using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEditor.Rendering;
using System.Runtime.CompilerServices;

public class InteractableObject : MonoBehaviour
{
    //Returns ItemName
    public string ItemName;

    [SerializeField] private Sprite woodSprite; // Add this line

    //For Evergrowing Tree!
    public string Description;
    public int ObjectHealth;

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public InteractableObject interactableObject;

    public Transform focusTransform;

    Vector3 initialPosition; // Gets the objects position.
   // public GameObject respawnObject; // Assign the prefab in the Inspector
    bool isActive = true;
    //public GameObject originalObject;

    public XPManager xpManager;
    public RespawnTree respawnTree;


    //meow
    public static Inventory inventoryInstance;

    private void Awake()
    {
        if (inventoryInstance == null)
        {
            inventoryInstance = FindObjectOfType<Inventory>();
            if (inventoryInstance == null)
            {
                Debug.LogError("No Inventory instance found in the scene.");
            }
        }
        else
        {
            Debug.LogError("Duplicate instance of Inventory found. Destroying this one.");
            //Destroy(this.gameObject);
        }
    }


    private void Start()
    {

        if (xpManager == null)
        {
            Debug.LogError("XPManager is not assigned to InteractableObject.");
        }
        initialPosition = transform.position; // Store the initial position of the object
        //Instantiate(respawnObject);
    }

    void Update()
    {
        if (isFocus)    // If currently being focused
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (!hasInteracted && distance <= radius)
            {
                // Interact with the object
                hasInteracted = true;
                Interact();
            }
        }
    }


    public string GetItemName()
    {

        return ItemName;

    }


    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }

    // This method is meant to be overwritten
    public void Interact()
    {

    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
         
    }

    public void FocusFromPlayer(InteractableObject playerObject)
    {
        focusTransform = playerObject.transform;

        if (playerObject != null)
        {
            //Debug.Log("Hit: " + playerObject.Description + "!");
            //Debug.Log("FocusFromPlayer");
            EverGrowingTree(playerObject);
        }
    }

    private void AddWoodToInventory()
    {
        Item woodItem = new Item
        {
            itemName = "Wood",
            icon = woodSprite // This should be a Sprite object already loaded in your resources
        };

        if (!Inventory.instance.Add(woodItem))
        {
            Debug.Log("Failed to add Wood to Inventory");
        }
        else
        {
            Debug.Log("Wood added to Inventory");
        }
    }

    public void EverGrowingTree(InteractableObject playerObject)
    {
        // Check if the playerObject is null
        if (playerObject == null)
        {
            Debug.LogError("playerObject is null in EverGrowingTree");
            return; // Exit the method if playerObject is null
        }

        // Check if the Description property on playerObject is null
        if (playerObject.Description == null)
        {
            Debug.LogError("Description on playerObject is null in EverGrowingTree");
            return; // Exit the method if Description is null
        }

        // Now that we've ensured playerObject and its Description are not null, we can safely continue
        if (playerObject.Description == "infinite")
        {
            //Debug.Log("Tree Damaged");
            ObjectHealth -= 10;
            Debug.Log("Object Health: " + ObjectHealth);

            if (ObjectHealth <= 0)
            {
                // Check if xpManager is null
                if (xpManager == null)
                {
                    Debug.LogError("xpManager is not set in EverGrowingTree");
                    return; // Exit the method if xpManager is null
                }

                xpManager.GainXP(35); // Call GainXP method
                AddWoodToInventory();
                Debug.Log("Adding Wood");
                //StartCoroutine(respawnTree.RespawnTreeWithDelay(3f, this.gameObject));

                if (isActive)
                {
                    isActive = false;
                    // DestroyImmediate(originalObject, true); // Uncomment if needed
                }
            }
        }
        else
        {
            Debug.Log("Item is not the EverGrowingTree!");
        }

    }



}

