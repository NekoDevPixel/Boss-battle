using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    public GameObject smashAttack;
    public GameObject thrustAttack;

    private void Start()
    {
        smashAttack.SetActive(false);
        thrustAttack.SetActive(false);
    }

    public void OnsmashAttack()
    {
        Debug.Log("OnsmashAttack called");
        smashAttack.SetActive(true);
        Invoke("DeactivateSmashAttack", 0.5f); // 0.5초 후에 비활성화
    }

    public void OnThrustAttack()
    {
        Debug.Log("OnThrustAttack called");
        thrustAttack.SetActive(true);
        Invoke("DeactivateThrustAttack", 0.5f); // 0.5초 후에 비활성화
    }

    private void DeactivateThrustAttack()
    {
        thrustAttack.SetActive(false);
    }
    private void DeactivateSmashAttack()
    {
        smashAttack.SetActive(false);
    }


    
}
