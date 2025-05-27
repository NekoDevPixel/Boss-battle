using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{

    private Animator animator;
    private PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.playerHealth <= 0)
        {
            OnDeath(); // 플레이어의 체력이 0 이하일 때 OnDeath 메서드 호출
        }
        
    }

    void OnDeath()
    {
        animator.SetTrigger("Death");
        if (playerInput != null)
            playerInput.enabled = false;
    }
    
}
