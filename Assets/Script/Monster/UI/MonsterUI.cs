using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    public Slider healthSlider;
    public float smoothSpeed = 5f;
    private float targetFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.value = GameManager.Instance.monsterHealth / GameManager.Instance.monsterMaxHealth;
    }

    void Update()
    {
        showHealth();
    }

    void showHealth()
    {
        // 실제 체력 계산
        targetFill = GameManager.Instance.monsterHealth / GameManager.Instance.monsterMaxHealth;

        // 부드럽게 슬라이더 값 변화
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetFill, Time.deltaTime * smoothSpeed);
    }
    
}