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
                return null;
            }
            return instance;
        }
    }

    [Header("플레이어 공격력")]
    public int playerAttackDamage = 20; // 플레이어의 공격력

    [Header("플레이어 기본 체력")]
    public int playerMaxHealth = 100; // 플레이어의 초기 체력
    public float playerHealth; // 플레이어의 현재 체력

    [Header("플레이어 기본 공격력")]
    public int playerAttackPower = 10; // 플레이어의 초기 공격력

    [Header("플레이어 기본 방어력")]
    public int playerDefensePower = 5; // 플레이어의 초기 방어력

    [Header("몬스터 기본 체력")]
    public int monsterMaxHealth = 50; // 몬스터의 초기 체력}
    public float monsterHealth; // 몬스터의 현재 체력

    private void Awake()
    {
        playerHealth = playerMaxHealth; // 게임 시작 시 플레이어의 체력을 최대 체력으로 초기화
        monsterHealth = monsterMaxHealth; // 게임 시작 시 몬스터의 체력을 최대 체력으로 초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 게임 매니저를 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지
        }
    }

}
