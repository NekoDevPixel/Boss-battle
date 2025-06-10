using UnityEngine;

public class linoleumDelay : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    Color color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    void Update()
    {
        color.a += Time.deltaTime * 0.2f; // 알파값을 시간에 따라 증가시킴
        spriteRenderer.color = color;
    }
}
