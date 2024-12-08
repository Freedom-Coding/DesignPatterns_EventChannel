using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthEvent onPlayerHealthChanged;
    [SerializeField] private VoidEvent onPlayerDied;

    [SerializeField] private float maxHealth = 100;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        onPlayerHealthChanged.Invoke(new HealthPayload(currentHealth, maxHealth, -damage));

        if (currentHealth <= 0) onPlayerDied.Invoke(new EmptyPayload());
    }
}
