using UnityEngine;

public class CombatDebugHelper : MonoBehaviour
{
    [Header("Debug Info")]
    [SerializeField] private bool showDebugLogs = true;

    void Start()
    {
        if (showDebugLogs)
        {
            Debug.Log("=== COMBAT DEBUG HELPER ===");
            CheckPlayerSetup();
            CheckChickenSetup();
        }
    }

    void CheckPlayerSetup()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("❌ NO PLAYER FOUND! Make sure player has 'Player' tag.");
            return;
        }

        Debug.Log("✓ Player found: " + player.name);

        // Check PlayerHealth
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health == null)
            Debug.LogError("❌ PlayerHealth script NOT found on player!");
        else
            Debug.Log("✓ PlayerHealth found - Max Health: " + health.GetMaxHealth());

        // Check PlayerMeleeAttack
        PlayerMeleeAttack attack = player.GetComponent<PlayerMeleeAttack>();
        if (attack == null)
            Debug.LogError("❌ PlayerMeleeAttack script NOT found on player!");
        else
            Debug.Log("✓ PlayerMeleeAttack found");

        // Check Collider
        Collider col = player.GetComponent<Collider>();
        CharacterController cc = player.GetComponent<CharacterController>();
        if (col == null && cc == null)
            Debug.LogError("❌ Player has NO COLLIDER or CharacterController!");
        else
            Debug.Log("✓ Player has collider/controller");
    }

    void CheckChickenSetup()
    {
        ChickenAI chicken = FindObjectOfType<ChickenAI>();
        if (chicken == null)
        {
            Debug.LogError("❌ NO CHICKEN FOUND! Make sure ChickenAI script is attached.");
            return;
        }

        Debug.Log("✓ Chicken found: " + chicken.name);

        // Check ChickenHealth
        ChickenHealth health = chicken.GetComponent<ChickenHealth>();
        if (health == null)
            Debug.LogError("❌ ChickenHealth script NOT found on chicken!");
        else
            Debug.Log("✓ ChickenHealth found - Max Health: " + health.maxHealth);

        // Check Rigidbody
        Rigidbody rb = chicken.GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("❌ Rigidbody NOT found on chicken!");
        else
            Debug.Log("✓ Rigidbody found");

        // Check Collider
        Collider col = chicken.GetComponent<Collider>();
        if (col == null)
            Debug.LogError("❌ Collider NOT found on chicken!");
        else
        {
            Debug.Log("✓ Collider found - Is Trigger: " + col.isTrigger);
            if (col.isTrigger)
                Debug.LogWarning("⚠️ Chicken collider is set as TRIGGER - combat may not work!");
        }

        // Check Animator
        Animator anim = chicken.GetComponentInChildren<Animator>();
        if (anim == null)
            Debug.LogError("❌ Animator NOT found on chicken!");
        else
            Debug.Log("✓ Animator found");
    }
}
