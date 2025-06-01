using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager instance is null! Ensure it exists in the scene.");
            }
            return instance;
        }
    }

    [Header("플레이어 공격력")]
    public int playerAttackDamage = 20; // 플레이어의 공격력

    [Header("플레이어 기본 체력")]
    public int playerMaxHealth = 100; // 플레이어의 초기 체력
    public float playerHealth; // 플레이어의 현재 체력

    [Header("플레이어 스테미나")]
    public float playerStamina = 0f; // 플레이어의 초기 스테미나
    [Header("플레이어 최대 스테미나")]
    public float playerMaxStamina = 100f; // 플레이어의 최대 스테미나
    [Header("플레이어 스테미나 소모량")]
    public float playerStaminaConsumption = 25f; // 플레이어의 스테미나 소모량
    [Header("플레이어 스테미나 회복량")]
    public float playerStaminaRecovery = 10f; // 플레이어의 스테미나 회복량

    [Header("플레이어 기본 공격력")]
    public int playerAttackPower = 10; // 플레이어의 초기 공격력

    [Header("플레이어 기본 방어력")]
    public int playerDefensePower = 5; // 플레이어의 초기 방어력

    [Header("몬스터 기본 체력")]
    public int monsterMaxHealth = 100; // 몬스터의 초기 체력}
    public float monsterHealth; // 몬스터의 현재 체력
    [Header("몬스터 충돌 피해량")]
    public int monsterHit = 5;
    [Header("몬스터 발사체 공격력")]
    public int monsterAttackDamage = 10; // 몬스터의 발사체 공격력

    private void Awake()
    {
        playerHealth = playerMaxHealth; // 게임 시작 시 플레이어의 체력을 최대 체력으로 초기화
        monsterHealth = monsterMaxHealth; // 게임 시작 시 몬스터의 체력을 최대 체력으로 초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 나 자신이 중복된 경우 삭제
        }
    }

    

    public void InStamina()
    {
        Debug.Log("Stamina increased!");
        if (playerStamina >= playerMaxStamina)
        {
            playerStamina = playerMaxStamina; // 스테미나가 최대치를 넘지 않도록 보장
            return;
        }
        playerStamina += playerStaminaRecovery; // 스테미나 회복
    }
    public void OutStamina()
    {
        playerStamina -= playerStaminaConsumption; // 스테미나 소모
        if (playerStamina < 0)
        {
            playerStamina = 0; // 스테미나가 음수가 되지 않도록 보장
        }
    }

}
