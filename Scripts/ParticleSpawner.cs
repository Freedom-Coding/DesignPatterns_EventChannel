using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject damageParticle;
    [SerializeField] private GameObject healParticle;

    [SerializeField] private float duration = 2;
    [SerializeField] private float scaleMultiplier = 1.5f;

    public void Spawn(HealthPayload healthPayload)
    {
        GameObject objectToSpawn = healthPayload.delta > 0 ? healParticle : damageParticle;

        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawnedObject.transform.localScale *= scaleMultiplier;
        Destroy(spawnedObject, duration);
    }
}
