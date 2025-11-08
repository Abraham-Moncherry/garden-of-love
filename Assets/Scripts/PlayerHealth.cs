using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("UI References")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image healthFill;

    [Header("Health Colors")]
    [SerializeField] private Color fullHealthColor = Color.green;
    [SerializeField] private Color lowHealthColor = Color.red;

    [Header("Death Settings")]
    [SerializeField] private float deathDelay = 2f; // Delay before showing game over menu

    private GameOver gameOverScript;
    private AudioManager audioManager;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverScript = FindObjectOfType<GameOver>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponentInChildren<Animator>();

        UpdateHealthUI();
    }

    void Update()
    {
        // Removed K key damage trigger - was causing unexpected respawns
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     TakeDamage(20);
        // }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Don't take damage if already dead

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Play hit sound when taking damage
        if (audioManager != null && currentHealth > 0)
        {
            audioManager.PlaySFX(audioManager.hit);
        }

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;

            // Hide health bar when health is zero
            if (currentHealth <= 0)
            {
                healthSlider.gameObject.SetActive(false);
            }
        }

        if (healthFill != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthFill.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
        }
    }

    private void Die()
    {
        if (isDead) return; // Prevent multiple death calls
        isDead = true;

        Debug.Log("Player has died!");

        // Trigger death animation
        if (animator != null)
        {
            animator.SetTrigger("Death");
            Debug.Log("Death animation triggered");
        }

        // Disable player movement (if you have a movement script)
        ThirdPersonController controller = GetComponent<ThirdPersonController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        // Show game over menu after delay (to let death animation play)
        Invoke("ShowGameOver", deathDelay);
    }

    private void ShowGameOver()
    {
        if (gameOverScript != null)
        {
            gameOverScript.TriggerGameOver();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }
}