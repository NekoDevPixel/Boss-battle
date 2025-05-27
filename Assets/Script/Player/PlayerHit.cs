using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // private GameManager gameManager;
    private Animator animator;

    private bool isHit = false; // 플레이어가 맞았는지 여부
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // gameManager = FindFirstObjectByType<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnHit();
    }

    void OnHit()
    {
        if (isHit)
        {
            animator.SetTrigger("Hit"); // 맞았을 때 애니메이션 트리거
            GameManager.Instance.playerHealth -= 10; // 예시로 10만큼 체력 감소
            isHit = false; // 맞았음을 초기화
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 적과 충돌했을 때
        {
            isHit = true; // 플레이어가 맞았음을 표시
        }
    }
}
