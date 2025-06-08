using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // private GameManager gameManager;
    private Animator animator;

    private bool istouch = false; // 플레이어가 맞았는지 여부
    private bool isSProjectileHit = false; // 투사체에 맞았는지 여부
    private bool isLProjectileHit = false; // 대형 투사체에 맞았는지 여부
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
        if (istouch)
        {
            // 맞았을 때 애니메이션 트리거
            HitAnimation();
            BossIFM.Instance.touchD(); // 플레이어가 보스에게 닿았을 때 피해량 적용
            istouch = false; // 맞았음을 초기화
        }
        if (isSProjectileHit)
        {
            // 투사체에 맞았을 때 애니메이션 트리거
            HitAnimation();
            BossIFM.Instance.SprojectileD(); // 보스의 투사체에 맞았을 때 피해량 적용
            isSProjectileHit = false; // 투사체 맞았음을 초기화
        }
        if (isLProjectileHit)
        {
            // 대형 투사체에 맞았을 때 애니메이션 트리거
            HitAnimation();
            BossIFM.Instance.LprojectileD(); // 보스의 대형 투사체에 맞았을 때 피해량 적용
            isLProjectileHit = false; // 대형 투사체 맞았음을 초기화
        }
    }

    public void HitAnimation()
    {
        animator.SetTrigger("Hit");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 적과 충돌했을 때
        {
            istouch = true; // 플레이어가 맞았음을 표시
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile")) // 투사체에 맞았을 떄
        {
            isSProjectileHit = true; // 투사체에 맞았음을 표시
        }
        if (collision.CompareTag("LProjectile")) // 대형 투사체에 맞았을 때
        {
            isLProjectileHit = true; // 대형 투사체에 맞았음을 표시
        }
    }
}
