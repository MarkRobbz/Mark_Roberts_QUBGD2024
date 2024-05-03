using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player
    public float mouseSensitivity = 100.0f; // Sensitivity of the mouse
    public Transform playerCamera; // The camera attached to  player
    public Rigidbody rb; // The Rigidbody attached to this object
    private float xRotation = 0.0f; // Variable to store the vertical rotation of the camera
    public float jumpForce = 5.0f; // Jump force added
    //public float extraGravityForce = 2.0f;
    public float fallMultiplier = 2.5f; //increase rate of decent
    public float lowJumpMultiplier = 2f; //control height of jump

    private bool isGrounded; // Ground check flag added
    

    void Start()
    {
        InitialisePlayer();
    }

    void Update()
    {
        HandleCameraMovement();
        HandleJumpInput();
        ModifyJumpHeight();
    }

    void FixedUpdate()
    {
        MovePlayer();
       // if (!isGrounded && rb.velocity.y < 0)
      //  {
      //      rb.AddForce(Vector3.down * extraGravityForce); // Apply extra downward force
       // }
    }
    
    // Collision detection to check if the player is grounded
    void OnCollisionEnter(Collision collision)
    {
        CheckIfGrounded(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void InitialisePlayer()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Ensure there is a Rigidbody component attached
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        // Ensure the player has a camera assigned
        if (playerCamera == null)
        {
            Debug.LogError("PlayerController: No camera attached!");
        }
    }

    private void MovePlayer()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction relative to where the player is facing
        Vector3 forwardMovement = transform.forward * moveVertical;
        Vector3 sidewaysMovement = transform.right * moveHorizontal;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + (forwardMovement + sidewaysMovement) * speed * Time.fixedDeltaTime);
    }

    private void HandleCameraMovement()
    {
        // Mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate camera rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to camera and player
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    private void HandleJumpInput()
    {
        // Jump input check
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void ModifyJumpHeight()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    private void CheckIfGrounded(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}