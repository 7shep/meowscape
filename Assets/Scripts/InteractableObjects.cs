using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private bool PlayerInRangeOfObject;
    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerInRangeOfObject = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRangeOfObject= false;
        }
    }
}
