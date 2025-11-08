using UnityEngine;
using UnityEngine.UI;

public class SpiderHealthBarUI : MonoBehaviour
{
    [SerializeField] SpiderHealth health;
    [SerializeField] Image barFill;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2f, 0);

    void Start()
    {
        health.OnHealthChanged += UpdateHealthBar;
        health.OnDeath += HideBar;

        // Initialize health bar to full (green)
        if (barFill != null)
        {
            barFill.fillAmount = 1f;
            barFill.color = Color.green;
        }
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;

        transform.LookAt(Camera.main.transform);
    }

    void UpdateHealthBar(float normalizedHealth)
    {
        if (barFill == null) return;

        barFill.fillAmount = normalizedHealth;

        // Color gradient: green (full health) to red (low health)
        barFill.color = Color.Lerp(Color.red, Color.green, normalizedHealth);
    }

    void HideBar()
    {
        gameObject.SetActive(false);
    }
}
