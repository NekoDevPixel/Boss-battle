using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("플레이어 체력UI")]
    public Slider healthSlider;
    public float smoothSpeed = 5f;
    private float targetFill;

    [Header("플레이어 스테미나UI")]
    public Slider staminaSlider;
    private float staminaSmoothSpeed = 5f;

    void Start()
    {
        staminaSlider.value = 0f; // 초기 스테미나 값 설정
        targetFill = 1f;
        healthSlider.value = 1f;
    }

    void Update()
    {
        showHealth();
        showStamina();
    }

    void showHealth()
    {
        // 실제 체력 계산
        targetFill = GameManager.Instance.playerHealth / GameManager.Instance.playerMaxHealth;

        // 부드럽게 슬라이더 값 변화
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetFill, Time.deltaTime * smoothSpeed);
    }

    void showStamina()
    {
        // 실제 스테미나 계산
        float targetStamina = GameManager.Instance.playerStamina / 100f;

        if (Mathf.Abs(staminaSlider.value - targetStamina) > 0.01f)
        {
            staminaSlider.value = Mathf.Lerp(staminaSlider.value, targetStamina, Time.deltaTime * staminaSmoothSpeed);
        }
    }

}
