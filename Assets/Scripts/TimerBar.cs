using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerbar;

    private float currentTime = 3f; // ���� �ð�
    private bool isTimerActive;     // Ÿ�̸Ӱ� Ȱ��ȭ�Ǿ� �ִ��� ���θ� Ȯ��
    private bool isInCenter; // ����Ű�� Center �ȿ� �ִ��� ���θ� Ȯ��

    private void Start()
    {
        timerbar = GetComponentInChildren<Slider>();
        timerbar.gameObject.SetActive(false); // Ÿ�̸� �ٸ� ��Ȱ��ȭ

        isTimerActive = false;
        isInCenter = false;
    }

    private void Update()
    {
        if (isTimerActive)
        {
            currentTime -= Time.deltaTime;

            // Ÿ�̸� �ٸ� ������Ʈ
            float fillAmount = currentTime / 3f; // 3�ʷ� ����� ���� ä���� ���� ���
            timerbar.value = fillAmount;

            if (currentTime <= 0 || !isInCenter)
            {
                // Ÿ�̸Ӱ� �Ϸ�Ǿ��ų� ����Ű�� Center�� �������
                ResetTimer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // ����Ű�� Center �ȿ� �������� ��
            isInCenter = true;

            // �÷��̾ ���� �ڽ��� �����ϸ� Ÿ�̸� Ȱ��ȭ �� Ÿ�̸� �� Ȱ��ȭ
            isTimerActive = true;
            timerbar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // ����Ű�� Center�� ����� ��
            isInCenter = false;

            // �÷��̾ ���� �ڽ��� ����� Ÿ�̸� ��Ȱ��ȭ
            isTimerActive = false;

            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        isTimerActive = false;  // Ÿ�̸Ӱ� ��Ȱ��ȭ �Ǹ�
        currentTime = 3f; // Ÿ�̸Ӹ� �ʱⰪ���� �缳��
    }

    public void OnDestroy()
    {
        ResetTimer();
    }
}
