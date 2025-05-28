using System.Collections;
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
        StartCoroutine(SmashAttackRoutine());
    }

    public void OnThrustAttack()
    {
        Debug.Log("OnThrustAttack called");
        StartCoroutine(ThrustAttackRoutine());
    }

    private IEnumerator SmashAttackRoutine()
    {
        smashAttack.SetActive(true);

        //Collider를 살짝 이동해서 OnTriggerEnter2D 유도
        smashAttack.transform.position += Vector3.right * 0.01f;

        yield return new WaitForSeconds(0.1f); // 충돌 감지를 위한 유지 시간
        yield return new WaitForFixedUpdate(); // 물리 처리 보장

        smashAttack.SetActive(false);

        // 원래 위치로 되돌리기 (필수)
        smashAttack.transform.position -= Vector3.right * 0.01f;
    }

    private IEnumerator ThrustAttackRoutine()
    {
        thrustAttack.SetActive(true);

        //Collider를 살짝 이동해서 OnTriggerEnter2D 유도
        thrustAttack.transform.position += Vector3.right * 0.01f;

        yield return new WaitForSeconds(0.1f);
        yield return new WaitForFixedUpdate();

        thrustAttack.SetActive(false);

        //원래 위치로 되돌리기 (반드시!)
        thrustAttack.transform.position -= Vector3.right * 0.01f;
    }   
    
    
}
