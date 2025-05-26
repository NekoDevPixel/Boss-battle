using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("플레이어 기본 체력")]
    public int playerMaxHealth = 100; // 플레이어의 초기 체력
    public int playerHealth; // 플레이어의 현재 체력

    [Header("플레이어 기본 공격력")]
    public int playerAttackPower = 10; // 플레이어의 초기 공격력

    [Header("플레이어 기본 방어력")]
    public int playerDefensePower = 5; // 플레이어의 초기 방어력

    void Start()
    {
        playerHealth = playerMaxHealth; // 게임 시작 시 플레이어의 체력을 최대 체력으로 초기화
    }

}
