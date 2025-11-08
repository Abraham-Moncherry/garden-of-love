using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private int attackDamage = 5; // Reduced from 10 to 5 to make game harder
    [SerializeField] private float attackRange = 5f; // Increased from 2.5f to 5f for easier hitting
    [SerializeField] private float attackCooldown = 0.5f;

    [Header("References")]
    [SerializeField] private Transform attackPoint; // Position from where attack is performed (optional)
    [SerializeField] private Animator animator;

    private float attackTimer = 0f;
    private Camera mainCamera;
    private int attackCount = 0; // Track number of attacks

    void Start()
    {
        mainCamera = Camera.main;

        // Get animator if not assigned
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    void Update()
    {
        // Decrease cooldown timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        // Check for attack input (left mouse button or F key)
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Attack button pressed!");
            if (attackTimer <= 0f)
            {
                PerformAttack();
                attackTimer = attackCooldown;
            }
            else
            {
                Debug.Log("Attack on cooldown: " + attackTimer);
            }
        }
    }

    void PerformAttack()
    {
        attackCount++;
        Debug.Log("=== PERFORMING ATTACK #" + attackCount + " ===");

        // Play attack animation if available
        if (animator != null)
        {
            animator.SetTrigger("Attack");
            Debug.Log("Attack animation triggered");
        }
        else
        {
            Debug.LogWarning("No animator found on player!");
        }

        // Only deal damage on every 2nd attack
        if (attackCount % 2 != 0)
        {
            Debug.Log("Attack #" + attackCount + " - No damage (only every 2nd attack deals damage)");
            return;
        }

        Debug.Log("Attack #" + attackCount + " - WILL DEAL DAMAGE!");

        // Determine attack origin point
        Vector3 attackOrigin = attackPoint != null ? attackPoint.position : transform.position + Vector3.up * 1.0f;
        Debug.Log("Attack origin: " + attackOrigin + " | Range: " + attackRange);

        // Find all colliders in range (no layer filter needed)
        Collider[] hitColliders = Physics.OverlapSphere(attackOrigin, attackRange);
        Debug.Log("Found " + hitColliders.Length + " colliders in attack range");

        // Debug: List all found objects
        foreach (Collider col in hitColliders)
        {
            ChickenHealth ch = col.GetComponent<ChickenHealth>();
            ChickenHealth chInParent = col.GetComponentInParent<ChickenHealth>();
            ChickenHealth chInChildren = col.GetComponentInChildren<ChickenHealth>();

            Debug.Log("  - Found object: " + col.gameObject.name +
                      " | ChickenHealth on this: " + (ch != null) +
                      " | in parent: " + (chInParent != null) +
                      " | in children: " + (chInChildren != null));
        }

        // Deal damage to all enemies in range
        foreach (Collider col in hitColliders)
        {
            Debug.Log("Checking collider: " + col.gameObject.name);

            // Try to damage spider
            SpiderAI spider = col.GetComponent<SpiderAI>();
            if (spider != null)
            {
                spider.ReceiveDamage(attackDamage);
                Debug.Log("*** HIT SPIDER (via SpiderAI) for " + attackDamage + " damage! ***");
                return; // Exit after hitting spider
            }

            // Try to damage spider health directly if SpiderAI doesn't exist
            SpiderHealth spiderHealth = col.GetComponent<SpiderHealth>();
            if (spiderHealth != null)
            {
                spiderHealth.TakeDamage(attackDamage);
                Debug.Log("*** HIT SPIDER (via SpiderHealth) for " + attackDamage + " damage! ***");
                return; // Exit after hitting spider
            }

            // Try to damage chicken (check on collider, parent, or children)
            ChickenHealth chickenHealth = col.GetComponent<ChickenHealth>();
            if (chickenHealth == null)
                chickenHealth = col.GetComponentInParent<ChickenHealth>();
            if (chickenHealth == null)
                chickenHealth = col.GetComponentInChildren<ChickenHealth>();

            if (chickenHealth != null)
            {
                Debug.Log("Found ChickenHealth component! Current health: " + chickenHealth.currentHealth);
                chickenHealth.TakeDamage(attackDamage);
                Debug.Log("*** HIT CHICKEN for " + attackDamage + " damage! New health: " + chickenHealth.currentHealth + " ***");
                return; // Exit after hitting chicken
            }
            else
            {
                Debug.Log("Object " + col.gameObject.name + " has NO ChickenHealth component anywhere");
            }
        }

        Debug.Log("No enemy found in sphere range, trying raycast...");

        // Alternative: Raycast from camera forward if no enemies found in sphere
        RaycastHit hit;
        Vector3 rayOrigin = mainCamera.transform.position;
        Vector3 rayDirection = mainCamera.transform.forward;

        Debug.Log("Raycasting from camera: " + rayOrigin + " in direction: " + rayDirection);

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, attackRange * 2f))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name + " at distance: " + hit.distance);

            SpiderAI spider = hit.collider.GetComponent<SpiderAI>();
            if (spider != null)
            {
                spider.ReceiveDamage(attackDamage);
                Debug.Log("*** RAYCAST HIT SPIDER (via SpiderAI) for " + attackDamage + " damage! ***");
                return;
            }

            SpiderHealth spiderHealth = hit.collider.GetComponent<SpiderHealth>();
            if (spiderHealth != null)
            {
                spiderHealth.TakeDamage(attackDamage);
                Debug.Log("*** RAYCAST HIT SPIDER (via SpiderHealth) for " + attackDamage + " damage! ***");
                return;
            }

            ChickenHealth chickenHealth = hit.collider.GetComponent<ChickenHealth>();
            if (chickenHealth == null)
                chickenHealth = hit.collider.GetComponentInParent<ChickenHealth>();
            if (chickenHealth == null)
                chickenHealth = hit.collider.GetComponentInChildren<ChickenHealth>();

            if (chickenHealth != null)
            {
                Debug.Log("Found ChickenHealth via raycast! Current health: " + chickenHealth.currentHealth);
                chickenHealth.TakeDamage(attackDamage);
                Debug.Log("*** RAYCAST HIT CHICKEN for " + attackDamage + " damage! New health: " + chickenHealth.currentHealth + " ***");
                return;
            }

            Debug.Log("Hit object has no enemy components");
        }
        else
        {
            Debug.Log("Raycast didn't hit anything");
        }

        Debug.Log("=== ATTACK COMPLETE (No enemy hit) ===");
    }

    // Visualize attack range in editor
    void OnDrawGizmosSelected()
    {
        Vector3 attackOrigin = attackPoint != null ? attackPoint.position : transform.position + Vector3.up * 1.0f;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin, attackRange);
    }
}
