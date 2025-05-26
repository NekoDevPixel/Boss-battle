using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{

    Animator animator;
    PlayerMove movementScript;
    PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerMove>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // 임시 로직
        if (Input.GetKeyDown(KeyCode.K)) // K 키를 눌렀을 때 플레이어가 죽었다고 가정
        {
            OnDeath();
        }
        
    }

    void OnDeath()
    {
        // 플레이어가 죽었을 때 DeathCoroutine을 실행
        StartCoroutine(DeathCoroutine());
    }
    
    IEnumerator DeathCoroutine()
    {
        if (movementScript != null)
            movementScript.enabled = false;
        if (playerInput != null)
            playerInput.enabled = false;
        // 플레이어가 죽었을 때 실행할 애니메이션 트리거 설정

        animator.SetTrigger("Death");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // // 게임 오버 처리 또는 재시작 로직 추가
        // GameManager gameManager = FindObjectOfType<GameManager>();
        // if (gameManager != null)
        // {
        //     gameManager.playerHealth = 0; // 플레이어 체력 0으로 설정
        //     // 게임 오버 UI 표시 등 추가 로직
        // }
    }
}
