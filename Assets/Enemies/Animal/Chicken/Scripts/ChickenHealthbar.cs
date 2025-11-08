using UnityEngine;
using UnityEngine.UI;

public class ChickenHealthBarUI : MonoBehaviour
{
    [SerializeField] ChickenHealth health; // Changed from SpiderHealth
    [SerializeField] Image barFill;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2f, 0);

    void Start()
    {
        // Auto-find health if not assigned
        if (health == null && target != null)
        {
            health = target.GetComponent<ChickenHealth>();
        }

        if (health != null)
        {
            health.OnHealthChanged += UpdateHealthBar;
            health.OnDeath += HideBar;
        }
        else
        {
            Debug.LogError("ChickenHealthBarUI: Could not find ChickenHealth component!");
        }

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
        barFill.color = Color.Lerp(Color.red, Color.green, normalizedHealth);
    }

    void HideBar()
    {
        gameObject.SetActive(false);
    }
}