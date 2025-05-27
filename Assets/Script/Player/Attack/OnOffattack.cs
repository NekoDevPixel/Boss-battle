using UnityEngine;

public class OnOffattack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered: " + collision.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by attack: " + collision.name);
            // 적에게 데미지 주기
            // collision.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }
}
