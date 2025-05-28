using UnityEngine;

public class OnOffattack : MonoBehaviour
{
    private bool hasHit = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!hasHit && collision.CompareTag("Enemy"))
        {
            hasHit = true;
            Debug.Log("Enemy hit in TriggerStay: " + collision.name);
            GameManager.Instance.monsterHealth -= GameManager.Instance.playerAttackPower;
            // collision.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }

    private void OnDisable()
    {
        // 공격이 끝날 때 초기화
        hasHit = false;
    }
}
