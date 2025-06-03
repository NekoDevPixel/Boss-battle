using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // private GameManager gameManager;
    private Animator animator;

    private bool istouch = false; // 플레이어가 맞았는지 여부
    private bool isProjectileHit = false; // 투사체에 맞았는지 여부
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
            GameManager.Instance.playerHealth -= BossIFM.Instance.touchDamage; // 플레이어가 보스에게 닿았을 때 피해량 적용
            istouch = false; // 맞았음을 초기화
        }
        if(isProjectileHit)
        {
            // 투사체에 맞았을 때 애니메이션 트리거
            HitAnimation();
            GameManager.Instance.playerHealth -= BossIFM.Instance.projectileDamage; // 보스의 투사체에 맞았을 때 피해량 적용
            isProjectileHit = false; // 투사체 맞았음을 초기화
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
            isProjectileHit = true; // 투사체에 맞았음을 표시
        }
    }
}
