using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerbar;

    private float currentTime = 3f; // 남은 시간
    private bool isTimerActive;     // 타이머가 활성화되어 있는지 여부를 확인
    private bool isInCenter; // 방향키가 Center 안에 있는지 여부를 확인

    private void Start()
    {
        timerbar = GetComponentInChildren<Slider>();
        timerbar.gameObject.SetActive(false); // 타이머 바를 비활성화

        isTimerActive = false;
        isInCenter = false;
    }

    private void Update()
    {
        if (isTimerActive)
        {
            currentTime -= Time.deltaTime;

            // 타이머 바를 업데이트
            float fillAmount = currentTime / 3f; // 3초로 나누어서 바의 채워진 정도 계산
            timerbar.value = fillAmount;

            if (currentTime <= 0 || !isInCenter)
            {
                // 타이머가 완료되었거나 방향키가 Center를 벗어났을때
                ResetTimer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // 방향키가 Center 안에 진입했을 때
            isInCenter = true;

            // 플레이어가 센터 박스에 진입하면 타이머 활성화 및 타이머 바 활성화
            isTimerActive = true;
            timerbar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // 방향키가 Center를 벗어났을 때
            isInCenter = false;

            // 플레이어가 센터 박스를 벗어나면 타이머 비활성화
            isTimerActive = false;

            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        isTimerActive = false;  // 타이머가 비활성화 되면
        currentTime = 3f; // 타이머를 초기값으로 재설정
    }

    public void OnDestroy()
    {
        ResetTimer();
    }
}
