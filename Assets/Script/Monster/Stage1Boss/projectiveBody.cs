using UnityEngine;

public class projectiveBody : MonoBehaviour
{
    private float timer = 0f; // 타이머
    private bool isHit = false; // 충돌 여부
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러
    private Color color; // 스프라이트 색상

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color; // 스프라이트 색상 초기화
        color.a = 0f; // 알파값을 1로 설정 (완전히 불투명)
        spriteRenderer.color = color; // 색상 적용
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = color; // 색상 적용
        color.a += Time.deltaTime * 0.15f; // 알파값을 시간에 따라 증가시킴
        timer += Time.deltaTime;

        // 1초 후에 오브젝트를 파괴
        if (timer >= 20f)
        {
            Destroy(gameObject);
        }
        if (isHit)
        {
            if(GameManager.Instance.playerHealth <= 0) // 플레이어가 죽었을 때
            {
                return; // 함수 종료
            }
            else
            {
                Destroy(gameObject); // 충돌 후 오브젝트 파괴
            }
           
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isHit)
        {
            isHit = true; // 충돌 처리 후 더 이상 충돌하지 않도록 설정
            Debug.Log("Player Hit!");
            
        }
    }
}
