using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class InteractableObject : MonoBehaviour
{
    public string ItemName;

    public string GetItemName()
    {

        return ItemName;
        
    }

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;
    public int objectHealth;

    public Transform focusTransform;

    //meow

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

        if (playerObject != null )
        {
            Debug.Log(playerObject.ItemName);
            Debug.Log("FocusFromPlayer");
        }
    }

    void EverGrowingTree(Transform objectHealth)
    {
        Debug.Log("Evergrow");
    }


}

