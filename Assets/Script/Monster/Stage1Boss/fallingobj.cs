using UnityEngine;

public class fallingobj : MonoBehaviour
{
    public SpriteRenderer linoleumRenderer; // 스프라이트 렌더러
    public GameObject fallingOBJ;
    public GameObject linoleum; // 리노륨 오브젝트
    private bool isFalling = false; // 낙하 여부
    Color color;
    Vector3 spawnPos;

    void Start()
    {
        
        spawnPos = new Vector3(
        linoleum.transform.position.x,
        linoleum.transform.position.y + 10f,
        linoleum.transform.position.z
        );
    }

    void Update()
    {
        color = linoleumRenderer.color;
        FallingOBJ();
    }

    void FallingOBJ()
    {
        if (color.a >= 1.0f && isFalling == false) // 올바른 비교
        {
            isFalling = true; // 낙하 시작
            Instantiate(fallingOBJ, spawnPos,
            Quaternion.identity,GameObject.Find("Fobj").transform);
            
        }
    }
}
