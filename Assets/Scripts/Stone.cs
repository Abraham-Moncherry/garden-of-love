using UnityEngine;

public class Stone : MonoBehaviour
{
    [Header("Stone Settings")]
    [SerializeField] private float throwForce = 15f;
    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private float destroyAfterThrowDelay = 3f; // Time before stone disappears after being thrown
    [SerializeField] private float heldStoneScale = 0.3f; // Scale when held in hand

    private Rigidbody rb;
    private Collider stoneCollider;
    private MeshRenderer meshRenderer;
    private bool isHeld = false;
    private StoneSpawner spawner;
    private int originalLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        stoneCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        originalLayer = gameObject.layer;

        // Ensure the stone has a rigidbody
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.5f;
        }

        // Ensure the stone has a collider
        if (stoneCollider == null)
        {
            stoneCollider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)stoneCollider).radius = 0.1f;
        }

        // Check for mesh renderer
        if (meshRenderer == null)
        {
            Debug.LogWarning("Stone has no MeshRenderer! The stone will be invisible!");
        }
    }

    void Update()
    {
        // Debug: Show stone info when held
        if (isHeld && meshRenderer != null)
        {
            Debug.Log("HELD STONE - Pos: " + transform.position + " | Visible: " + meshRenderer.enabled + " | Active: " + gameObject.activeSelf);
        }
    }

    public void PickUp(Transform cameraTransform)
    {
        isHeld = true;

        // Notify spawner that stone was picked up
        if (spawner != null)
        {
            spawner.OnStonePickedUp();
        }

        // Disable physics while held
        rb.isKinematic = true;
        rb.useGravity = false;

        // Disable collider but keep it as trigger so it's still visible
        stoneCollider.isTrigger = true;

        // Ensure mesh renderer is enabled
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
            Debug.Log("Stone MeshRenderer enabled: " + meshRenderer.enabled);
            Debug.Log("Stone has material: " + (meshRenderer.material != null));
        }
        else
        {
            Debug.LogError("Stone MeshRenderer is NULL! Stone will be invisible!");
        }

        // Don't parent - just unparent if it was parented
        transform.SetParent(null);
        transform.localScale = Vector3.one * heldStoneScale; // Make it visible size when held

        // Ensure the GameObject is active
        gameObject.SetActive(true);

        Debug.Log("Stone picked up - Position will be updated by controller. Scale: " + transform.localScale);
    }

    public void Throw(Vector3 direction)
    {
        isHeld = false;

        // Unparent from player (if parented)
        transform.SetParent(null);

        // Reset scale to normal
        transform.localScale = Vector3.one * 0.2f;

        // Enable physics
        rb.isKinematic = false;
        rb.useGravity = true;
        stoneCollider.isTrigger = false; // Re-enable solid collider

        // Apply throw force
        rb.linearVelocity = direction * throwForce; // Use velocity instead of AddForce for more consistent throws

        Debug.Log("Stone thrown in direction: " + direction + " with force: " + throwForce + " from position: " + transform.position);

        // Destroy stone after delay to clean up and allow new spawn
        Destroy(gameObject, destroyAfterThrowDelay);
    }

    public bool IsHeld()
    {
        return isHeld;
    }

    public float GetPickupRange()
    {
        return pickupRange;
    }

    // Called by StoneSpawner to link this stone to its spawner
    public void SetSpawner(StoneSpawner stoneSpawner)
    {
        spawner = stoneSpawner;
    }
}
