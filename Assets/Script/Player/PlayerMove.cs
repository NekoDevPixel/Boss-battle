using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 move;

    [Header("플레이어 이동 속도")]
    public float speed = 5f;

    [Header("플레이어 대기 시간")]
    public float stopMoveTime = 3f;
    private float idleTimer = 0f;
    private Vector2 lastPosition;

    private PlayerAttack playerAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Standby_status();
        PlayerRun();
        left_right_twist();
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        rb.linearVelocity = new Vector2(move.x * speed, move.y * speed);
    }

    void PlayerRun()
    {
        animator.SetFloat("run", Mathf.Abs(move.x) + Mathf.Abs(move.y));
    }

    void left_right_twist()
    {
        if (move.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Standby_status()
    {
        //AI를 사용하여 코드 구현
        Vector2 currentPosition = transform.position;
        bool isMoving = (currentPosition - lastPosition).sqrMagnitude > 0.001f;
        bool isAttacking = playerAttack.isAttacking;

        if (isMoving || !isAttacking)
        {
            idleTimer = 0f;
            animator.ResetTrigger("Break");
            animator.SetBool("IsIdle", false);

        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= stopMoveTime)
            {
                animator.SetTrigger("Break"); // break 애니메이션 재생
            }
            else
            {
                animator.SetBool("IsIdle", true); // 기본 idle 유지
            }
        }

        lastPosition = currentPosition;
    }

    
    
    
    

}
