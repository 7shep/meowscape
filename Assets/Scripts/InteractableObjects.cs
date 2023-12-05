using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;

    public string GetItemName()
    {

        return ItemName;
        
    }

    public float radius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
         

    }
}
