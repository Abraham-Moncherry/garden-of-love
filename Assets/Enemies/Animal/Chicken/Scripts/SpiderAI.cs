using UnityEngine;

public enum SpiderState
{
    Idle,
    Chase,
    Attack,
    Dead
}

public class SpiderAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpiderHealth health;   // Custom spider health script
    [SerializeField] Animator animator;     // Animator with Idle/Walk/Attack/Death

    [Header("Detection Settings")]
    [SerializeField] float detectionRange = 10f; // How close girl must be to be noticed
    Transform target; // Player reference

    [Header("Attack Settings")]
    [SerializeField] float attackRange = 2f;
    [SerializeField] int attackDamage = 15;
    [SerializeField] float attackCooldown = 1.5f; // delay between attacks
    float attackTimer = 0f;

    private SpiderState currentState = SpiderState.Idle;

    [SerializeField] private GameObject bloodEffectPrefab;

    void Awake()
    {
        if (!health) health = GetComponent<SpiderHealth>();
        if (!animator) animator = GetComponentInChildren<Animator>();

        health.OnDeath += OnDeath;
    }

    void Start()
    {
        // Auto-find the girl using Player tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            target = playerObj.transform;
    }

    void Update()
    {
        if (currentState == SpiderState.Dead) return;

        switch (currentState)
        {
            case SpiderState.Idle:
                IdleBehaviour();
                CheckForPlayer();
                break;

            case SpiderState.Chase:
                ChaseBehaviour();
                break;

            case SpiderState.Attack:
                AttackBehaviour();
                break;
        }
    }

    void IdleBehaviour()
    {
        animator.SetBool("isWalking", false);

    }

    void CheckForPlayer()
    {
        if (!target) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            currentState = SpiderState.Chase;
            Debug.Log("Spider: Player detected!");
        }
    }

    void ChaseBehaviour()
    {
        if (!target) return;

        float distance = Vector3.Distance(transform.position, target.position);

        // Close enough → switch to Attack
        if (distance <= attackRange)
        {
            currentState = SpiderState.Attack;
            return;
        }

        // Face the player
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * 2f);

        // Play walking animation
        animator.SetBool("isWalking", true);

        // MOVE toward player
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            2f * Time.deltaTime
        );
    }

    void AttackBehaviour()
    {
        Debug.Log("ENTERING ATTACK STATE");

        if (!target) return;

        float distance = Vector3.Distance(transform.position, target.position);

        // If player moves out of attack range, go back to chase
        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false); // stop attack
            currentState = SpiderState.Chase;
            return;
        }

        // Stop walking
        animator.SetBool("isWalking", false);

        // Face the girl
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * 5f);

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            animator.CrossFade("Attack1", 0.05f); // Use exact name of your Attack animation state
            // animator.SetBool("isAttacking", true);  // START ATTACK
            Debug.Log("Spider Attacks!");
            DealDamageToPlayer();
            attackTimer = attackCooldown;
        }
    }

    void DealDamageToPlayer()
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            // Instantiate blood effect at player's position
            Instantiate(bloodEffectPrefab, target.position + Vector3.up * 1f, Quaternion.identity);
            Debug.Log("Player hit! Health reduced.");
        }
    }

    public void EndAttack()
    {
        animator.SetBool("isAttacking", false); // END ATTACK
    }

    void OnDeath()
    {
        currentState = SpiderState.Dead;
        animator.SetBool("Dead", true);

        Collider col = GetComponent<Collider>();
        if (col) col.enabled = false;

        // Flip spider 180 degrees to show it's dead
        StartCoroutine(FlipSpiderAndTransition());
    }

    System.Collections.IEnumerator FlipSpiderAndTransition()
    {
        // Smoothly rotate spider 180 degrees on X axis (flip upside down)
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(180f, 0f, 0f);

        // Store starting position
        Vector3 startPosition = transform.position;
        // Calculate end position (lift spider up so it stays above ground when flipped)
        Vector3 endPosition = startPosition + Vector3.up * 1.5f; // Adjust 1.5f value if needed

        float duration = 1.0f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        transform.position = endPosition;

        // Wait 2 seconds before transitioning
        yield return new UnityEngine.WaitForSeconds(2f);

        // Transition to final scene (index 5 in Build Settings)
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    // External damage from player
    public void ReceiveDamage(int amount)
    {
        health.TakeDamage(amount);
    }
}