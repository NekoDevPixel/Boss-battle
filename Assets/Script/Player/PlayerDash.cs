using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMove playerMove;
    public float dashSpeed = 20f;
    private Vector2 moveInput;
    private Vector2 lastMoveDir;
    public bool isDashing = false;

    private DashUI dashUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
        dashUI = FindFirstObjectByType<DashUI>();
    }

    void Update()
    {
        Vector2 currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // 대시 중이 아니면 입력 받음
        if (!isDashing)
        {
            moveInput = currentInput;


            if (moveInput != Vector2.zero)
            {
                lastMoveDir = moveInput;
            }

            // 일반 이동 속도 반영
            rb.linearVelocity = moveInput * playerMove.speed;
        }

        // 대시 키 입력 및 대시 중이 아닐 때만 대시 실행
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && currentInput != Vector2.zero && dashUI.CanDash())
        {
            StartCoroutine(Dash());
        }
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;

        // 대시 속도 적용
        rb.linearVelocity = lastMoveDir * dashSpeed;

        yield return new WaitForSeconds(0.1f);

        isDashing = false;
    }
}
