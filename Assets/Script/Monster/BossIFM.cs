using UnityEngine;

public class BossIFM : MonoBehaviour
{

    private static BossIFM instance;
    public static BossIFM Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("BossDamage instance is null! Ensure it exists in the scene.");
            }
            return instance;
        }
    }

    void Awake()
    {
        monsterHealth = monsterMaxHealth; // 게임 시작 시 몬스터의 체력을 최대 체력으로 초기화
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }   

    [Header("보스 피해량")]
    public float touchDamage = 10f; // 플레이어가 보스에게 닿았을 때 받는 피해량
    public float SprojectileDamage = 20f; // 보스의 투사체에 맞았을 때 받는 피해량
    public float LprojectileDamage = 30f; // 보스의 대형 투사체에 맞았을 때 받는 피해량
    public float linoleumDamage = 15f; // 보스의 리놀륨 공격에 맞았을 때 받는 피해량

    [Header("몬스터 기본 체력")]
    public int monsterMaxHealth = 100; // 몬스터의 초기 체력}
    public float monsterHealth = 0; // 몬스터의 현재 체력

    public void Beshot()
    {
        monsterHealth -= GameManager.Instance.playerAttackDamage;
    }

    public void touchD()
    {
        GameManager.Instance.playerHealth -= touchDamage; // 플레이어가 보스에게 닿았을 때 피해량 적용
    }

    public void SprojectileD()
    {
        GameManager.Instance.playerHealth -= SprojectileDamage; // 보스의 투사체에 맞았을 때 피해량 적용
    }

    public void LprojectileD()
    {
        GameManager.Instance.playerHealth -= LprojectileDamage; // 보스의 대형 투사체에 맞았을 때 피해량 적용
    }

    public void linoleumD()
    {
        GameManager.Instance.playerHealth -= linoleumDamage; // 보스의 리놀륨 공격에 맞았을 때 피해량 적용
    }
}
