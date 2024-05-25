
    using UnityEngine;

public class PickupAndThrow : MonoBehaviour
{
    public float pickupRange = 5f; // Range within where the player can pick up
    public float throwForce = 10f; // Force applied to thrown objects
    public Transform holdPosition; // Position where the object will be held

    private GameObject heldObject = null; // Currently held object
    private Rigidbody heldObjectRb = null; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }

        if (Input.GetMouseButtonDown(0) && heldObject != null)
        {
            ThrowObject();
        }

        if (heldObject != null)
        {
            // Keep the held object at the hold position
            heldObject.transform.position = holdPosition.position;
        }
    }

    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickup")) // Ensure the object has the "Pickup" tag
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();

                if (heldObjectRb != null)
                {
                    heldObjectRb.useGravity = false;
                    heldObjectRb.isKinematic = true; // Disable physics interaction while holding
                    heldObject.transform.position = holdPosition.position;
                    heldObject.transform.parent = holdPosition;
                }
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObjectRb.useGravity = true;
            heldObjectRb.isKinematic = false;
            heldObject.transform.parent = null;
            heldObject = null;
            heldObjectRb = null;
        }
    }

    void ThrowObject()
    {
        if (heldObject != null)
        {
            heldObjectRb.useGravity = true;
            heldObjectRb.isKinematic = false;
            heldObject.transform.parent = null;

            // Apply force to the held object in the forward direction
            heldObjectRb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

            heldObject = null;
            heldObjectRb = null;
        }
    }
}

