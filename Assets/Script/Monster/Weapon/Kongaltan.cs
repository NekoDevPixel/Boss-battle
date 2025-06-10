using Unity.VisualScripting;
using UnityEngine;

public class Kongaltan : MonoBehaviour
{
    private bool isHit = false; // Kongaltan이 플레이어에게 닿았는지 여부
    private float timer = 0f;
    private void Start()
    {
        
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
            if (GameManager.Instance.playerHealth <= 0) // 플레이어가 죽었을 때
            {
                return; // 함수 종료
            }
            else
            {
                 Destroy(gameObject); // 피격시 오브젝트 삭제
                isHit = false; // Kongaltan이 플레이어에게 닿았음을 초기화

            }
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
