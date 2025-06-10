using UnityEngine;
using System.Collections.Generic;

public class linoleumSPW : MonoBehaviour
{
    public GameObject spherePrefab;     // 생성할 구체 프리팹
    public int numberOfSpheres = 10;    // 생성할 구체 개수
    public CircleCollider2D spawnArea;       // 스폰 범위로 사용할 콜라이더
    

    private List<GameObject> spawnedSpheres = new List<GameObject>(); // 생성된 오브젝트 저장

    void Start()
    {      
        SpawnSpheres();
    }

   

    void SpawnSpheres()
    {
        

        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector2 randomPos = GetRandomPointInCircle(spawnArea);
            GameObject sphere = Instantiate(spherePrefab, randomPos, Quaternion.identity
            ,GameObject.Find("lino").transform);
            spawnedSpheres.Add(sphere);
        }
    }

    public void ClearSpheres()
    {
        foreach (GameObject sphere in spawnedSpheres)
        {
            if (sphere != null)
            {
                Destroy(sphere);
            }
        }
        spawnedSpheres.Clear();
    }

    Vector2 GetRandomPointInCircle(CircleCollider2D circle)
    {
        Vector2 center = (Vector2)circle.transform.position + circle.offset;
        float radius = circle.radius * Mathf.Max(circle.transform.lossyScale.x, circle.transform.lossyScale.y);  // 원형 크기 보정

        // 랜덤 반지름과 각도
        float angle = Random.Range(0f, Mathf.PI * 2);
        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * radius; // 밀도 균일하게 하기 위한 sqrt 처리

        float x = Mathf.Cos(angle) * distance;
        float y = Mathf.Sin(angle) * distance;

        return center + new Vector2(x, y);
    }
}
