using UnityEngine;

public class KongaltanManager : MonoBehaviour
{
    public Transform player;
    public GameObject kongaltanPrefab;
    public Transform firePoint;
    [Header("발사 속도")]
    public float speed = 5f;
    [Header("발사 간격")]
    public float fireInterval = 2f;
    private float timer = 0f;
    float healthPercent;

    void Awake()
    {
        
    }

    void Update()
    {
        healthPercent = BossIFM.Instance.monsterHealth / BossIFM.Instance.monsterMaxHealth;
        timer += Time.deltaTime;
        if (healthPercent >= 0.75f)
        {
            NomalAttack();
        }
        else if (healthPercent >= 0.5f)
        {
            OneUPAttack();
        }

    }

    void ShootKong()
    {
        GameObject kongaltan = Instantiate(kongaltanPrefab, firePoint.position, Quaternion.identity, GameObject.Find("Kongaltan").transform);
        Rigidbody2D rb = kongaltan.GetComponent<Rigidbody2D>();

        // firePoint가 바라보는 방향으로 발사
        Vector2 shootDirection = (player.position - firePoint.position).normalized;
        rb.linearVelocity = shootDirection * speed;
    }

    void NomalAttack()
    {
        if (timer >= fireInterval)
        {
            timer = 0f;
            ShootKong();
        }
    }
    void OneUPAttack()
    {
        fireInterval = 1f;
        if (timer >= fireInterval)
        {
            timer = 0f;
            for (int i = 0; i < 3; i++)
            {
                // 0.5초 간격으로 3번 발사
                Invoke("ShootKong", i * 0.5f);
            }
            // ShootKong();
        }
    }
}
