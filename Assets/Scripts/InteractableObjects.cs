using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEditor.Rendering;


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

    Vector3 initialPosition; // Gets the objects position.
    public GameObject respawnObject; // Assign the prefab in the Inspector
    bool isActive = true;
    public GameObject originalObject;


    //meow

    private void Start()
    {
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

    public void EverGrowingTree(InteractableObject playerObject
        )
    {
        if (playerObject.Description == "infinite")
        {
            Debug.Log("Tree Damaged");
            ObjectHealth -= 10;
            Debug.Log(ObjectHealth);

            if (ObjectHealth <= 0)
            {
                //Destroy(respawnObject); // Destroy the newly instantiated object
                StartCoroutine(TestSeconds(5f));
                if (isActive)
                {
                    isActive = false;
                    //Debug.Log("No longer active");
                    //DestroyImmediate(originalObject, true);
                }
            }
        }
        else
        {
            Debug.Log("Item is not the EverGrowingTree!");
        }
    }


    public void RespawnTree()
    {
        originalObject.SetActive(false);

    }

    IEnumerator TestSeconds(float delay)
    {
        Debug.Log("Started");
        originalObject.SetActive(false);

        yield return new WaitForSeconds(delay);

        respawnObject.SetActive(true);
        ObjectHealth = 100;
        Debug.Log("Finished");
    }


}

