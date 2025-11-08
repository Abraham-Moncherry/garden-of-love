using UnityEngine;
using System;

public class SpiderHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public event Action OnDeath;
    public event Action<float> OnHealthChanged; // sends health %

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(1f);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
