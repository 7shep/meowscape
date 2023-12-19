using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering;
using Unity.VisualScripting;

public class PlayerMovementAdvanced : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;


    public InteractableObject interactableObject; // Reference variable for InteractableObject


    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [Header("For Interaction")]
    public Camera Camera;
    public InteractableObject focus;
    Vector3 moveDirection;

    Rigidbody rb;

    public GameObject PausePanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

                RemoveFocus();

                if (interactableObject != null)
                {
                    Debug.Log("Hit " + interactableObject); // Log "Hit" to the console for InteractableObject
                    
                    SetFocus(interactableObject);
                    focus.FocusFromPlayer(interactableObject);
                }
            }
        }

    }

    void SetFocus(InteractableObject newFocus)
    {
        // Assign the newFocus parameter to the 'focus' variable
        focus = newFocus;

        // Check if 'interactableObject' is not null (assuming 'interactableObject' is another reference)
        if (interactableObject != null)
        {
            // Call the 'FocusFromPlayer' method of the 'focus' object
            // Pass 'interactableObject' as an argument to 'FocusFromPlayer'

            // Log a message to indicate that the interaction is being sent
            Debug.Log("Sending");
        }
    }



    void RemoveFocus()
    {
        focus = null;
    }

    private void FixedUpdate()
    {
        if (PausePanel.activeInHierarchy)
        {
            Debug.Log("pausepanel");
        }else
        {
            Debug.Log("nopausepanel");
            MovePlayer();
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // Project camera's forward and right vectors onto the horizontal plane (Y = 0)
        camForward.y = 0f;
        camRight.y = 0f;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        moveDirection = camForward * verticalInput + camRight * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
