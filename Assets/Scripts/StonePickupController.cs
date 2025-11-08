using UnityEngine;
using StarterAssets;

public class StonePickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] private Transform holdPosition;
    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private LayerMask stoneLayer;

    [Header("Throw Settings")]
    [SerializeField] private float throwForce = 15f;

    [Header("UI Settings")]
    [SerializeField] private GameObject pickupPrompt; // Optional UI prompt (e.g., "Press E to pick up")
    [SerializeField] private GameObject throwPrompt; // Optional UI prompt (e.g., "Press E to throw")

    private StarterAssetsInputs _input;
    private Stone heldStone;
    private Stone nearbyStone;
    private Camera mainCamera;
    private bool holdPositionCreated = false;
    private Animator animator; // NEW: For throw animation

    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        animator = GetComponentInChildren<Animator>(); // NEW: Get animator

        // Find main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("StonePickupController: Main Camera not found! Make sure your camera is tagged as 'MainCamera'");
                return;
            }
        }

        // Always create hold position
        CreateHoldPosition();

        // Hide prompts at start
        if (pickupPrompt != null)
        {
            pickupPrompt.SetActive(false);
            Debug.Log("StonePickupController: Pickup prompt assigned and hidden");
        }
        else
        {
            Debug.LogWarning("StonePickupController: No pickup prompt assigned - UI won't show");
        }

        if (throwPrompt != null)
        {
            throwPrompt.SetActive(false);
            Debug.Log("StonePickupController: Throw prompt assigned and hidden");
        }
        else
        {
            Debug.LogWarning("StonePickupController: No throw prompt assigned - UI won't show");
        }
    }

    void CreateHoldPosition()
    {
        if (holdPosition == null && mainCamera != null)
        {
            GameObject holdPosObj = new GameObject("StoneHoldPosition");
            holdPosition = holdPosObj.transform;
            holdPosition.SetParent(mainCamera.transform);
            // Position: right in front of camera, slightly to the right and down (like holding something)
            // Using local position relative to camera - should always be visible
            holdPosition.localPosition = new Vector3(0.4f, -0.3f, 1.0f);
            holdPosition.localRotation = Quaternion.identity;
            holdPositionCreated = true;
            Debug.Log("StonePickupController: Created hold position - Parent: " + mainCamera.name + " | Local Pos: " + holdPosition.localPosition + " | World Pos: " + holdPosition.position);
        }
        else if (holdPosition != null)
        {
            Debug.Log("StonePickupController: Hold position already assigned: " + holdPosition.name);
        }
    }

    void Update()
    {
        // Check for nearby stones if not holding one
        if (heldStone == null)
        {
            CheckForNearbyStone();
        }
        else
        {
            // Update stone position while held to follow camera
            UpdateHeldStonePosition();
        }

        // Handle pickup/throw input (E key or custom input)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed!");
            if (heldStone == null && nearbyStone != null)
            {
                Debug.Log("Attempting to pick up stone...");
                PickUpStone(nearbyStone);
            }
            else if (heldStone != null)
            {
                Debug.Log("Attempting to throw stone...");
                ThrowStone();
            }
            else
            {
                Debug.Log("No stone nearby to pick up");
            }
        }
    }

    void UpdateHeldStonePosition()
    {
        if (heldStone != null && mainCamera != null)
        {
            // Calculate position in front of camera
            Vector3 targetPosition = mainCamera.transform.position +
                                     mainCamera.transform.right * 0.4f +     // Right offset
                                     mainCamera.transform.up * -0.3f +        // Down offset
                                     mainCamera.transform.forward * 1.0f;     // Forward offset

            heldStone.transform.position = targetPosition;
            heldStone.transform.rotation = mainCamera.transform.rotation;
        }
    }

    void CheckForNearbyStone()
    {
        // First try raycast (looking directly at stone)
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * pickupRange, Color.yellow);

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            Stone stone = hit.collider.GetComponent<Stone>();
            if (stone != null && !stone.IsHeld())
            {
                nearbyStone = stone;
                Debug.Log("Stone detected by raycast!");

                // Show pickup prompt
                if (pickupPrompt != null)
                {
                    pickupPrompt.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Pickup prompt is not assigned!");
                }
                return;
            }
        }

        // Also check for nearby stones using sphere overlap (in case not looking directly at it)
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (Collider col in nearbyColliders)
        {
            Stone stone = col.GetComponent<Stone>();
            if (stone != null && !stone.IsHeld())
            {
                nearbyStone = stone;
                Debug.Log("Stone detected by sphere overlap!");

                // Show pickup prompt
                if (pickupPrompt != null)
                {
                    pickupPrompt.SetActive(true);
                }
                return;
            }
        }

        // No stone found
        nearbyStone = null;
        if (pickupPrompt != null)
        {
            pickupPrompt.SetActive(false);
        }
    }

    void PickUpStone(Stone stone)
    {
        // NEW: Trigger pickup animation
        if (animator != null)
        {
            animator.SetTrigger("PickUp");
            Debug.Log("Pickup animation triggered");
        }

        heldStone = stone;
        heldStone.PickUp(mainCamera.transform); // Pass camera transform instead

        // Hide pickup prompt
        if (pickupPrompt != null)
        {
            pickupPrompt.SetActive(false);
        }

        // Show throw prompt
        if (throwPrompt != null)
        {
            throwPrompt.SetActive(true);
        }

        Debug.Log("Picked up stone! Camera Y: " + mainCamera.transform.position.y + " | Stone Y: " + heldStone.transform.position.y);
    }

    void ThrowStone()
    {
        if (heldStone == null)
        {
            Debug.LogWarning("Cannot throw - no stone held!");
            return;
        }

        if (mainCamera == null)
        {
            Debug.LogError("Cannot throw - no camera found!");
            return;
        }

        // NEW: Trigger throw animation
        if (animator != null)
        {
            animator.SetTrigger("Throw");
            Debug.Log("Throw animation triggered");
        }

        // Calculate throw direction (camera forward with slight upward arc)
        Vector3 throwDirection = transform.forward;
        throwDirection.y = 0f;
        throwDirection.Normalize();

        // Add slight upward angle for better arc (optional - you can adjust or remove this)
        throwDirection += Vector3.up * 0.1f;

        Debug.Log("Throwing stone - Camera forward: " + throwDirection + " | Stone position before throw: " + heldStone.transform.position);

        // Throw the stone
        heldStone.Throw(throwDirection);

        // Clear reference
        heldStone = null;

        // Hide throw prompt
        if (throwPrompt != null)
        {
            throwPrompt.SetActive(false);
        }

        Debug.Log("Stone thrown successfully!");
    }

    // Public method to check if holding a stone
    public bool IsHoldingStone()
    {
        return heldStone != null;
    }

    // Optional: Draw debug gizmo to show pickup range
    void OnDrawGizmosSelected()
    {
        if (mainCamera != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * pickupRange);
        }
    }
}
