using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MonsterUI : MonoBehaviour
{
    [Header("몬스터 체력 슬라이더")]
    public Slider healthSlider;
    public float smoothSpeed = 5f;

    [Header("몬스터 체력 텍스트")]
    public TextMeshProUGUI healthText;

    private float targetFill;
    private float animatedHealth;
    private Tween healthTween;

    void Start()
    {
        float currentHealth = BossIFM.Instance.monsterHealth;
        float maxHealth = BossIFM.Instance.monsterMaxHealth;

        animatedHealth = currentHealth;
        healthSlider.value = currentHealth / maxHealth;
        UpdateHealthText((int)animatedHealth);
    }

    void Update()
    {
        ShowHealth();
        AnimateHealthText();
    }

    void ShowHealth()
    {
        targetFill = BossIFM.Instance.monsterHealth / BossIFM.Instance.monsterMaxHealth;
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetFill, Time.deltaTime * smoothSpeed);
    }

    void AnimateHealthText()
    {
        float currentHealth = BossIFM.Instance.monsterHealth;
        if (Mathf.Abs(animatedHealth - currentHealth) > 0.1f)
        {
            if (healthTween != null && healthTween.IsActive()) healthTween.Kill();

            healthTween = DOTween.To(() => animatedHealth, x => {
                animatedHealth = x;
                UpdateHealthText((int)animatedHealth);
            }, currentHealth, 0.3f).SetEase(Ease.OutQuad);
        }
    }

    void UpdateHealthText(int value)
    {
        healthText.text = $"{value}";
    }
}
