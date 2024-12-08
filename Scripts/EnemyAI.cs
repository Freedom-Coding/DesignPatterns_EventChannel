using System.Threading.Tasks;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float damageRange = 2;
    [SerializeField] private float damage = 10;
    [SerializeField] private Animator animator;
    [SerializeField] private string attackAnimationName;

    private void Start()
    {
        DealDamagePeriodically();
    }

    private async void DealDamagePeriodically()
    {
        while (enabled)
        {
            int waitTime = Random.Range(2, 3);
            await Task.Delay(waitTime * 1000);

            if (!Application.isPlaying) return;

            animator.Play(attackAnimationName);
            await Task.Delay(300);

            RaycastHit2D hitInfo = Physics2D.BoxCast(transform.position, Vector2.one, 0, transform.right * -1, damageRange);

            if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.ReceiveDamage(damage);
            }
        }
    }
}
