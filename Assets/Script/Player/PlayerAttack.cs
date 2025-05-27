using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    public bool isAttacking = false;
    private PlayerMove playerMove;
    Coroutine currentAttackCoroutine;
    public CheckAttack checkAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        if (checkAttack == null)
        {
            checkAttack = transform.Find("Attack").GetComponent<CheckAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
        StopAttackOnMove();
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

    void StopAttackOnMove()
    {
        if (!isAttacking) return;

        if (playerMove.move != Vector2.zero)
        {
            isAttacking = false;

            if (currentAttackCoroutine != null)
            {
                StopCoroutine(currentAttackCoroutine);
                currentAttackCoroutine = null;
            }

            animator.ResetTrigger("Smash");
            animator.ResetTrigger("Thrust");

            StartCoroutine(ReturnToIdleDelayed(0.01f)); // 짧은 시간 후 idle 전환
        }
    }


    IEnumerator SmashCorutine()
    {
        animator.SetTrigger("Smash");
        yield return new WaitForSeconds(1.4f);
        EndAttack("Smash");
    }

    IEnumerator ThrustCorutine()
    {
        animator.SetTrigger("Thrust");
        yield return new WaitForSeconds(1.25f);
        EndAttack("Thrust");
    }

    IEnumerator ReturnToIdleDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsIdle", false);
    }

    void EndAttack(string triggerName)
    {
        animator.ResetTrigger(triggerName);
        animator.SetBool("IsIdle", false);
        isAttacking = false;
    }

    public void OnSmashEvent()
    {
        checkAttack.OnsmashAttack();
    }

    public void OnThrustEvent()
    {
        checkAttack.OnThrustAttack();
    }
}
