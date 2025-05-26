using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    public bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
    }

    void OnAttack()
    {
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true; // 공격 상태를 false로 설정
            StartCoroutine(SmashCorutine());
        }
        else if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse1))
        {
            isAttacking = true; // 공격 상태를 false로 설정
            StartCoroutine(ThrustCorutine());
        }
    }

    IEnumerator SmashCorutine()
    {
        animator.SetTrigger("Smash");
        // float clipLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(1.4f);
        animator.ResetTrigger("Smash");
        animator.SetBool("IsIdle", false); // 공격 후 idle 상태로 전환
        isAttacking = false; // 공격 상태를 false로 설정
    }

    IEnumerator ThrustCorutine()
    {
        animator.SetTrigger("Thrust");
        // float clipLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(1.25f);
        animator.ResetTrigger("Thrust");
        animator.SetBool("IsIdle", false); // 공격 후 idle 상태로 전환
        isAttacking = false; // 공격 상태를 false로 설정
    }
}
