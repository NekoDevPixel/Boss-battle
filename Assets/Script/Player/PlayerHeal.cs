using System.Collections;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    // GameManager gameManager;
    Animator animator;
    private PlayerMove playerMove;
    [Header("플레이어 체력 회복")]
    public float healAmount = 10f; // 회복할 체력 양
    private int playerMaxH;
    private bool isHealing = false; // 회복 중인지 여부

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
        // gameManager = FindFirstObjectByType<GameManager>();
        playerMaxH = GameManager.Instance.playerMaxHealth; // 게임 매니저에서 플레이어 최대 체력 가져오기
    }

    void Update()
    {

        OnHeal();
        StopHeal();
    }

    void OnHeal()
    {
        if (!isHealing && Input.GetKeyDown(KeyCode.H) && GameManager.Instance.playerHealth < playerMaxH) // 예: H 키를 눌렀을 때 힐 실행
        {
            isHealing = true;
            StartCoroutine(HealCoroutine());
        }
    }

    void StopHeal()
    {
        if (playerMove.move != Vector2.zero)
        {
            isHealing = false; // 이동 중에는 힐을 중지
            animator.SetBool("IsIdle", true); // 이동 중에는 idle 상태로 전환
            return;
        }
    }
    

    IEnumerator HealCoroutine()
    {
        animator.SetTrigger("Heal");
        yield return new WaitForSeconds(1.3f);  // 공격 코루틴과 동일하게 1.3초 대기
        animator.ResetTrigger("Heal");
        animator.SetBool("IsIdle", true);  // 공격 코루틴과 동일하게 false로 설정
        isHealing = false;

        // // 힐 효과 적용 (예시)
        // HealPlayer(20);  // 20만큼 체력 회복 함수 호출
    }

    void HealPlayer(float amount)
    {
        // 플레이어의 체력을 회복하는 로직
        GameManager.Instance.playerHealth += amount;
        if (GameManager.Instance.playerHealth > playerMaxH)
        {
            GameManager.Instance.playerHealth = playerMaxH; // 최대 체력 초과 방지
        }
        Debug.Log("플레이어 체력 회복: " + amount);
    }

    public void OnAnimationEnd()
    {
        Debug.Log("애니메이션이 끝났습니다!");
        HealPlayer(20);
    }
}
