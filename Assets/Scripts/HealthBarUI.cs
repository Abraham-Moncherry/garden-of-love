using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Health Bar Components")]
    [SerializeField] private Image healthBarBack;
    [SerializeField] private Image healthBarFront;
    [SerializeField] private Slider healthSlider;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (healthSlider == null)
        {
            healthSlider = GetComponent<Slider>();
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = 1f;
            healthSlider.value = 1f; // Ensure slider starts full
        }

        if (healthBarFront != null)
        {
            healthBarFront.fillAmount = 1f; // Ensure front bar starts full
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = playerHealth.GetHealthPercentage();

        if (healthSlider != null)
        {
            healthSlider.value = healthPercentage;
        }

        if (healthBarFront != null)
        {
            healthBarFront.fillAmount = healthPercentage;
        }
    }
}