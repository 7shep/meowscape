using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public XPManager xpManager;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float xpDistanceThreshold = 10.0f;  // Adjust the distance threshold as needed.
    public int xpAmount = 10;  // Adjust the XP amount to your preference.
    private Vector3 previousPosition;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.magnitude, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, previousPosition) >= xpDistanceThreshold)
            {
                // Give the player XP using the XPManager
                xpManager.GainXP(xpAmount);
                previousPosition = transform.position;
            }

            Debug.Log(xpAmount);

        }

    }
}
