using UnityEngine;

[CreateAssetMenu(fileName = "Health event", menuName = "Events/Health event")]
public class HealthEvent : AbstractEvent<HealthPayload>
{

}

[System.Serializable]
public struct HealthPayload
{
    public float currrentHealth;
    public float maxHealth;
    public float delta;

    public HealthPayload(float _currentHealth, float _maxHealth, float _delta)
    {
        currrentHealth = _currentHealth;
        maxHealth = _maxHealth;
        delta = _delta;
    }
}