using System.Collections;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    GameManager gameManager;
    Animator animator;
    [Header("플레이어 체력 회복")]
    public float healAmount = 10f; // 회복할 체력 양
    private int playerMaxH;
    private bool isHealing = false; // 회복 중인지 여부

    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindFirstObjectByType<GameManager>();
        playerMaxH = gameManager.playerMaxHealth; // 게임 매니저에서 플레이어 최대 체력 가져오기
    }

    void Update()
    {
        OnHeal();
    }

    void OnHeal()
    {
        if (!isHealing && Input.GetKeyDown(KeyCode.H)) // 예: H 키를 눌렀을 때 힐 실행
        {
            isHealing = true;
            StartCoroutine(HealCoroutine());
        }
    }

    IEnumerator HealCoroutine()
    {
        animator.SetTrigger("Heal");
        yield return new WaitForSeconds(1.3f);  // 공격 코루틴과 동일하게 1.3초 대기

        animator.ResetTrigger("Heal");
        // animator.SetBool("IsIdle", true);  // 공격 코루틴과 동일하게 false로 설정
        isHealing = false;

        // // 힐 효과 적용 (예시)
        // HealPlayer(20);  // 20만큼 체력 회복 함수 호출
    }
}
