using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image damageOverlayImage;
    [SerializeField] private Gradient damageOverlayGradient;
    [SerializeField] private float fadeTime = 1;

    private bool isFadingOverlay = false;

    public void UpdateHealthSlider(HealthPayload healthPayload)
    {
        healthSlider.value = healthPayload.currrentHealth;
        healthSlider.maxValue = healthPayload.maxHealth;
    }

    public async void FadeDamageOverlay(HealthPayload healthPayload)
    {
        if (healthPayload.currrentHealth < healthPayload.maxHealth / 2 && !isFadingOverlay)
        {
            isFadingOverlay = true;
            float currentTime = 0;

            while (currentTime < fadeTime)
            {
                damageOverlayImage.color = damageOverlayGradient.Evaluate(currentTime / fadeTime);

                currentTime += Time.deltaTime;
                await Task.Yield();
            }

            isFadingOverlay = false;
        }
    }
}