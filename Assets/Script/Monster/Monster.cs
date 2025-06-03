using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool isHit = false;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black; // 초기 색상을 검은색으로 설정
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            if (!isHit)
            {
                isHit = true;
                StartCoroutine(HitEffect());
            }
        }
    }
    IEnumerator HitEffect()
    {
        Debug.Log("Monster Hit");
        spriteRenderer.color = Color.white;
        BossIFM.Instance.Beshot();
        yield return new WaitForSeconds(0.1f); // 0.2초 동안 흰색 유지
        spriteRenderer.color = Color.black;
        isHit = false;
    }

}
