using UnityEngine;

public class projectiveBody : MonoBehaviour
{
    private float timer = 0f; // 타이머
    private bool isHit = false; // 충돌 여부

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 1초 후에 오브젝트를 파괴
        if (timer >= 20f)
        {
            Destroy(gameObject);
        }
        if (isHit)
        {
           Destroy(gameObject); // 충돌 후 오브젝트 파괴
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
