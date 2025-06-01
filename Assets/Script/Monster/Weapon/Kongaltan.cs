using Unity.VisualScripting;
using UnityEngine;

public class Kongaltan : MonoBehaviour
{
    private PlayerHit playerHit; // 플레이어의 Hit 스크립트 참조
    private bool isHit = false; // Kongaltan이 플레이어에게 닿았는지 여부
    private void Start()
    {
        playerHit = FindFirstObjectByType<PlayerHit>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHit = true; // Kongaltan이 플레이어에게 닿았음을 표시
        }
    }

    private void Update() {
        KongaltanHit(); // Kongaltan이 플레이어에게 닿았는지 확인
    }

    void KongaltanHit()
    {
        if (isHit)
        {
            playerHit.HitAnimation(); // 플레이어의 Hit 애니메이션 실행
            Destroy(gameObject); // 피격시 오브젝트 삭제
            isHit = false; // Kongaltan이 플레이어에게 닿았음을 초기화
            
            GameManager.Instance.playerHealth -= GameManager.Instance.monsterHit; // 플레이어 체력 감소
        }
    }
}
