using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class InteractableObject : MonoBehaviour
{
    //Returns ItemName
    public string ItemName;

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

    Vector3 initialPosition; // For destroying the tree
    public GameObject respawnPrefab; // Assign the prefab in the Inspector


    //meow

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position of the object
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

    public void EverGrowingTree(InteractableObject playerObject)
    {
        if (playerObject.Description == "infinite")
        {
            Debug.Log("Tree Damaged");
            ObjectHealth -= 10;
            Debug.Log(ObjectHealth);

            if (ObjectHealth <= 0)
            {
                Destroy(gameObject); // Destroy the game object itself
                StartCoroutine(RespawnObjectAfterDelay(5f)); // Start coroutine to respawn after 5 seconds (for testing)
            }
        }
        else
        {
            Debug.Log("Item is not the EverGrowingTree!");
        }
    }

    IEnumerator RespawnObjectAfterDelay(float delay)
    {
        Debug.Log("Respawn coroutine started");
        yield return new WaitForSeconds(delay);

        // Respawn a new object after the delay using a prefab at the initial position
        GameObject newObject = Instantiate(respawnPrefab, initialPosition, Quaternion.identity);
        newObject.SetActive(true); // Activate the newly spawned object

        Debug.Log("Object respawned");
    }


}

