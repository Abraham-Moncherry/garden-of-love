using UnityEngine;
using UnityEngine.SceneManagement;

public enum ChickenState
{
    Idle,
    Walk,
    Chase,
    Attack
}

[RequireComponent(typeof(Rigidbody))]
public class ChickenAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ChickenHealth health;

    [Header("Detection Settings")]
    [SerializeField] private float walkRange = 15f;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 5f; // Increased from 2f to 5f
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Attack Settings")]
    [SerializeField] private float jumpForce = 2f; // Vertical jump - reduced to prevent landing on Elara
    [SerializeField] private float forwardForce = 6f; // Horizontal jump - increased for forward lunge
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int attackDamage = 15; // Damage dealt to player
    private float attackTimer = 0f;

    private Transform target;
    private ChickenState currentState = ChickenState.Idle;
    private bool isGrounded = true;

    private bool wantsToJump = false;
    private Vector3 moveDirection;

    void Awake()
    {
        // Auto-find components if not assigned
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (health == null)
            health = GetComponent<ChickenHealth>();

        // Setup rigidbody
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        if (animator != null)
            animator.applyRootMotion = false;
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            target = playerObj.transform;
            
        if (health != null)
            health.OnDeath += HandleDeath;
    }

    void Update()
    {
        isGrounded = CheckGrounded();
        attackTimer -= Time.deltaTime;

        if (target == null)
        {
            currentState = ChickenState.Idle;
        }

        moveDirection = Vector3.zero;

        switch (currentState)
        {
            case ChickenState.Idle:
                IdleBehaviour();
                break;

            case ChickenState.Walk:
                WalkBehaviour();
                break;

            case ChickenState.Chase:
                ChaseBehaviour();
                break;

            case ChickenState.Attack:
                AttackBehaviour();
                break;
        }
    }

    void FixedUpdate()
    {
        if (wantsToJump)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            Vector3 jumpVector = transform.forward * forwardForce + Vector3.up * jumpForce;
            rb.AddForce(jumpVector, ForceMode.Impulse);

            wantsToJump = false;
        }
        else if (currentState == ChickenState.Walk || currentState == ChickenState.Chase)
        {
            float speed = (currentState == ChickenState.Chase) ? runSpeed : walkSpeed;
            
            Vector3 targetVelocity = moveDirection * speed;
            targetVelocity.y = rb.linearVelocity.y;
            rb.linearVelocity = targetVelocity;
        }
    }

    void IdleBehaviour()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);

        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        
        if (distance <= walkRange) 
        {
            if (isGrounded && attackTimer <= 0f)
            {
                Debug.Log("Chicken is alerted and jumps!");
                
                Vector3 direction = (target.position - transform.position).normalized;
                direction.y = 0;
                transform.rotation = Quaternion.LookRotation(direction);

                wantsToJump = true;
                attackTimer = attackCooldown;
            }

            currentState = ChickenState.Walk; 
            Debug.Log("Chicken sees the girl, starts walking.");
        }
    }

    void WalkBehaviour()
    {
        if (target == null)
        {
            currentState = ChickenState.Idle;
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= chaseRange)
        {
            currentState = ChickenState.Chase;
            return;
        }
        
        if (distance > walkRange)
        {
            currentState = ChickenState.Idle;
            return;
        }

        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime
        );

        moveDirection = direction;
    }

    void ChaseBehaviour()
    {
        if (target == null)
        {
            currentState = ChickenState.Idle;
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            currentState = ChickenState.Attack;
            return;
        }
        
        if (distance > chaseRange)
        {
            currentState = ChickenState.Walk;
            return;
        }

        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", true);

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime
        );

        moveDirection = direction;
    }

    void AttackBehaviour()
    {
        if (target == null)
        {
            currentState = ChickenState.Idle;
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        float chaseThreshold = attackRange * 1.2f; 
        if (distance > chaseThreshold)
        {
            currentState = ChickenState.Chase;
            return;
        }

        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);

        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            rotationSpeed * Time.deltaTime * 2f
        );

        if (attackTimer <= 0f && isGrounded)
        {
            Debug.Log("Chicken jumps to attack!");
            wantsToJump = true; 
            attackTimer = attackCooldown;
        }
    }

    bool CheckGrounded()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.1f;
        float rayLength = 0.7f; 
        Debug.DrawRay(rayStart, Vector3.down * rayLength, Color.red);
        return Physics.Raycast(rayStart, Vector3.down, rayLength);
    }

    void HandleDeath()
    {
        Debug.Log("Chicken has died!");

        enabled = false;
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;

        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetTrigger("isDead");

        // Load Scene 5 after death animation
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    System.Collections.IEnumerator LoadNextSceneAfterDelay()
    {
        // Wait for death animation to play
        yield return new WaitForSeconds(2f);

        // Load Scene 5 (FinalScene)
        Debug.Log("Loading Scene 5 (FinalScene)");
        SceneManager.LoadScene(5);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit the player while jumping/attacking
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chicken collided with player!");

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("*** CHICKEN HIT PLAYER for " + attackDamage + " damage! ***");
            }
        }
    }
}