using UnityEngine;
using System.Collections;

public class SpawnAndRotate : MonoBehaviour
{
    [Header("💠 타겟 오브젝트")]
    public Transform Monster;  // 회전 중심 (예: 소환 위치 또는 몬스터 본체)
    public Transform player;   // 공격 대상 (예: 플레이어)

    [Header("🌀 회전 설정")]
    public float rotationSpeed = 360f; // 회전 속도 (도/초)
    private float Mspeed;
    public float radius = 2f;          // 날개들이 회전할 반지름

    [Header("🗡️ 날개(블레이드) 설정")]
    public GameObject bladePrefab;     // 날개 프리팹
    public int bladeCount = 4;         // 생성할 날개 수

    [Header("🚀 발사 설정")]
    public float speed = 5f;           // 날개 발사 속도
    public float shootDelay = 0.2f;    // 날개 발사 간격 (초)

    private Transform[] blades;        // 회전 중 생성된 날개들
    public bool hasFired = false;     // 한 번만 발사되도록 설정
    public float Rtimer = 30f;          // 리셋 타이머
    public float spintimer = 10f;
    public float timer = 0f;          // 타이머

    void Start()
    {
        Mspeed = rotationSpeed; // 초기 회전 속도 저장
        rotaion(); // 날개 생성
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!hasFired)
            Uprotaion();

        if (hasFired == false && timer >= spintimer)
        {
            Debug.Log("애니메이션 끝, 발사 시작");
            rotationSpeed = 0f;
            hasFired = true;
            StartCoroutine(ShootBladesSequentially());
        }

        if (Rtimer <= timer)
        {
            ResetSpawn();
            timer = 0f;
        }
    }


    // 날개를 일정 각도로 회전 배치
    void rotaion()
    {
        blades = new Transform[bladeCount];

        for (int i = 0; i < bladeCount; i++)
        {
            float angle = i * Mathf.PI * 2 / bladeCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            GameObject blade = Instantiate(bladePrefab, transform.position + pos
            , Quaternion.identity,transform);
            blades[i] = blade.transform;
        }
    }

    // 몬스터 위치에 따라 회전 유지
    void Uprotaion()
    {
        transform.position = Monster.position;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    // 날개를 하나씩 플레이어 방향으로 발사
    IEnumerator ShootBladesSequentially()
    {
        for (int i = 0; i < blades.Length; i++)
        {
            Transform blade = blades[i];

            // 회전 부모에서 분리
            blade.SetParent(null);

            // Rigidbody2D가 없으면 추가
            Rigidbody2D rb = blade.GetComponent<Rigidbody2D>();
            if (rb == null)
                rb = blade.gameObject.AddComponent<Rigidbody2D>();

            rb.gravityScale = 0; // 중력 제거
            Vector2 shootDirection = (player.position - blade.position).normalized;
            rb.linearVelocity = shootDirection * speed;

            yield return new WaitForSeconds(shootDelay); // 다음 발사까지 대기
        }
    }

    public void ResetSpawn()
    {
        // // 기존 블레이드 제거
        // if (blades != null)
        // {
        //     for (int i = 0; i < blades.Length; i++)
        //     {
        //         if (blades[i] != null)
        //             Destroy(blades[i].gameObject);
        //     }
        // }

        // 상태 초기화
        hasFired = false;

        // 블레이드 다시 생성
        rotaion();

        rotationSpeed = Mspeed; // 회전 속도 초기화
    }

}
