using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    [Header("플레이어 체력UI")]
    public Slider healthSlider;
    public float smoothSpeed = 5f;
    private float targetFill;
    private float animatedHealth;

    [Header("플레이어 스테미나UI")]
    public Slider staminaSlider;
    private float staminaSmoothSpeed = 5f;
    private float animatedStamina;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI staminaText;

    private Tween healthTween;
    private Tween staminaTween;

    void Start()
    {
        staminaSlider.value = 0f;
        targetFill = 1f;
        healthSlider.value = 1f;

        animatedHealth = GameManager.Instance.playerHealth;
        animatedStamina = GameManager.Instance.playerStamina;

        UpdateHealthText((int)animatedHealth);
        UpdateStaminaText((int)animatedStamina);
    }

    void Update()
    {
        showHealth();
        showStamina();
        AnimateHealthText();
        AnimateStaminaText();
    }

    void showHealth()
    {
        targetFill = GameManager.Instance.playerHealth / GameManager.Instance.playerMaxHealth;
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetFill, Time.deltaTime * smoothSpeed);
    }

    void showStamina()
    {
        float targetStamina = GameManager.Instance.playerStamina / 100f;
        if (Mathf.Abs(staminaSlider.value - targetStamina) > 0.01f)
        {
            staminaSlider.value = Mathf.Lerp(staminaSlider.value, targetStamina, Time.deltaTime * staminaSmoothSpeed);
        }
    }

    void AnimateHealthText()
    {
        float currentHealth = GameManager.Instance.playerHealth;
        if (Mathf.Abs(animatedHealth - currentHealth) > 0.1f)
        {
            if (healthTween != null && healthTween.IsActive()) healthTween.Kill();

            healthTween = DOTween.To(() => animatedHealth, x => {
                animatedHealth = x;
                UpdateHealthText((int)animatedHealth);
            }, currentHealth, 0.3f).SetEase(Ease.OutQuad);
        }
    }

    void AnimateStaminaText()
    {
        float currentStamina = GameManager.Instance.playerStamina;
        if (Mathf.Abs(animatedStamina - currentStamina) > 0.1f)
        {
            if (staminaTween != null && staminaTween.IsActive()) staminaTween.Kill();

            staminaTween = DOTween.To(() => animatedStamina, x => {
                animatedStamina = x;
                UpdateStaminaText((int)animatedStamina);
            }, currentStamina, 0.3f).SetEase(Ease.OutQuad);
        }
    }

    void UpdateHealthText(int value)
    {
        healthText.text = $"{value}";
    }

    void UpdateStaminaText(int value)
    {
        staminaText.text = $"{value}";
    }
}
