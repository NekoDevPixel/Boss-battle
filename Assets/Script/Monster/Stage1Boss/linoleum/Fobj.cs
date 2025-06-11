using UnityEngine;

public class Fobj : MonoBehaviour
{
    private linoleumSPW linoleumSpawner; // 리노륨 스폰 스크립트
    private bool isFallHit = false; // 낙하 여부
    private bool isFallPHit = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        linoleumSpawner = FindFirstObjectByType<linoleumSPW>();
    }

    // Update is called once per frame
    void Update()
    {
        FallingOBJ();
    }

    void FallingOBJ()
    {
        if (isFallHit)
        {
            linoleumSpawner.ClearSpheres(); // 리노륨 스폰어의 ClearSpheres 메소드 호출
            Destroy(gameObject); // 낙하가 시작되면 오브젝트 제거
            isFallHit = false;
        }
        if (isFallPHit)
        {
            linoleumSpawner.ClearSpheres(); // 플레이어와 충돌 시 리노륨 스폰어의 ClearSpheres 메소드 호출
            Destroy(gameObject); // 오브젝트 제거
            isFallPHit = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Linoleum") && !isFallHit)
        {
            isFallHit = true; // 낙하가 시작되었음을 표시
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isFallPHit = true; // 플레이어와 충돌했음을 표시
        }
    }
}
