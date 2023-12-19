using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTree : MonoBehaviour
{
    public GameObject treePrefab; // Assign the tree prefab in Unity Editor

    // This method will respawn the tree after a delay

    public IEnumerator RespawnTreeWithDelay(float delay, GameObject treeToReset)
    {
        // Hide the tree
        treeToReset.SetActive(false);

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Reset the tree's health and reactivate it
        InteractableObject interactableObject = treeToReset.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            interactableObject.ObjectHealth = 100; // Reset health to 100
        }

        treeToReset.SetActive(true);
    }

}