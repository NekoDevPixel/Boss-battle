using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public Slider[] DashSlider;
    private PlayerDash playerDash;
    public float rechargeTime = 2f; // 슬라이더가 다시 차는 데 걸리는 시간
    private float[] currentCooldowns;

    private int rechargeIndex = 0; // 현재 회복 중인 슬롯 인덱스
    private float rechargeTimer = 0f; // 회복 시간 누적

    void Start()
    {
        playerDash = FindFirstObjectByType<PlayerDash>();
        currentCooldowns = new float[DashSlider.Length];

        for (int i = 0; i < DashSlider.Length; i++)
        {
            DashSlider[i].value = 1f;
            Debug.Log($"DashSlider[{i}] = {DashSlider[i].gameObject.name}");
            currentCooldowns[i] = 0f;
        }
    }

    private bool wasDashing = false;

    void Update()
    {
        useDash();
        RechargeDash();
    }

    // 대시 사용 시 슬라이더 하나 소모
    void useDash()
    {   
        if (playerDash.isDashing && !wasDashing)
        {
            for (int i = DashSlider.Length - 1; i >= 0; i--) // 오른쪽부터 확인
            {
                if (DashSlider[i].value == 1f)
                {
                    DashSlider[i].value = 0f;

                    // 방금 소모된 인덱스가 회복 인덱스보다 앞이면 회복 인덱스를 되돌림
                    if (i < rechargeIndex)
                    {
                        rechargeIndex = i;
                        rechargeTimer = 0f; // 새로 시작
                    }
                    break;
                }
            }
        }
        wasDashing = playerDash.isDashing;
    }
    // 슬라이더 자동 회복
    void RechargeDash()
    {
        // 회복 대상 찾기: 0이면서 가장 왼쪽에 있는 칸
        while (rechargeIndex < DashSlider.Length && DashSlider[rechargeIndex].value == 1f)
        {
            rechargeIndex++;
        }

        // 회복할 칸이 없으면 return
        if (rechargeIndex >= DashSlider.Length)
            return;

        // 회복 타이머 누적
        rechargeTimer += Time.deltaTime;

        // 2초가 지나면 해당 칸 회복
        if (rechargeTimer >= 2f)
        {
            DashSlider[rechargeIndex].value = 1f;
            rechargeTimer = 0f;
            rechargeIndex++; // 다음 칸으로 넘어감
        }
    }

    // 대시 가능 여부 체크
    public bool CanDash()
    {
        foreach (Slider slider in DashSlider)
        {
            if (slider.value == 1f)
                return true;
        }
        return false;
    }
}

