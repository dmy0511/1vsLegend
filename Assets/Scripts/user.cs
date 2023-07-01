using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user : MonoBehaviour
{
    public Slider user_hp; // ������� ü���� ǥ���ϴ� �����̴�
    public GameObject GameOver; // GameOver�� ǥ���ϴ� ���� ������Ʈ
    private Animator animator; // �ִϸ�����

    private float maxhp = 100; // �ִ� ü��
    private float curhp = 100; // ���� ü��

    private com comScript; // com ��ũ��Ʈ

    private void Awake()
    {
        comScript = FindObjectOfType<com>(); // com ��ũ��Ʈ ��������
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
    }

    void Start()
    {
        user_hp.value = (float)curhp / (float)maxhp; // ���� ü���� �����̴��� �ݿ�
    }

    void Update()
    {
        HandleHp(); // ü�� ������Ʈ

        if (curhp <= 0)
        {
            string savedData = comScript.scoretext.text; // com ��ũ��Ʈ���� �ؽ�Ʈ ��������

            GameObject bestTextObject = GameObject.Find("BestText"); // "BestText" ������Ʈ ã��
            if (bestTextObject != null)
            {
                Text bestText = bestTextObject.GetComponent<Text>(); // "BestText" ������Ʈ���� Text ������Ʈ ��������
                if (bestText != null)
                {
                    bestText.text = savedData; // "BestText" �ؽ�Ʈ ������Ʈ
                }
            }

            comScript.ResetHealth(); // com ��ũ��Ʈ�� ü�� �ʱ�ȭ
            comScript.showQuestionMark = false; // com ��ũ��Ʈ���� ����ǥ ǥ�ø� ��Ȱ��ȭ
            comScript.UpdateScoreText(); // com ��ũ��Ʈ�� ���� �ؽ�Ʈ ������Ʈ

            Time.timeScale = 0;

            GameOver.SetActive(true);
        }
        else
        {
            user_hp.value = curhp / maxhp; // ���� ü���� �����̴��� �ݿ�
        }
    }

    private void HandleHp()
    {
        user_hp.value = (float)curhp / (float)maxhp; // ���� ü���� �����̴��� �ݿ�
    }

    public void DefenseFail(float amount)
    {
        curhp -= amount; // ���� ü�� ����
        curhp = Mathf.Clamp(curhp, 0, maxhp); // ���� ü���� �ִ� ü���� ���� �ʵ��� ����
    }
}
