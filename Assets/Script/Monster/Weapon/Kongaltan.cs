using Unity.VisualScripting;
using UnityEngine;

public class Kongaltan : MonoBehaviour
{
    private PlayerHit playerHit; // 플레이어의 Hit 스크립트 참조
    private bool isHit = false; // Kongaltan이 플레이어에게 닿았는지 여부
    private float timer = 0f;
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
            // playerHit.HitAnimation(); // 플레이어의 Hit 애니메이션 실행
            Destroy(gameObject); // 피격시 오브젝트 삭제
            isHit = false; // Kongaltan이 플레이어에게 닿았음을 초기화

            // GameManager.Instance.playerHealth -= GameManager.Instance.monsterHit; // 플레이어 체력 감소
        }
        else
        {
            timer += Time.deltaTime; // Kongaltan이 플레이어에게 닿지 않았을 때 타이머 증가
            if (timer >= 10f) // 2초 후에 Kongaltan 삭제
            {
                Destroy(gameObject);
                timer = 0f; // 타이머 초기화
            }
        }
    }
}
