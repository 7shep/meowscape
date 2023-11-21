using UnityEngine;

public class KeepOnGround : MonoBehaviour
{
    public float maxGroundDistance = 0.2f; // Adjust this value based on your game's scale

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxGroundDistance))
        {
            float distanceToGround = hit.distance;
            transform.position -= new Vector3(0, distanceToGround, 0);
        }
    }
}
