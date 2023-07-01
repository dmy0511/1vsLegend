using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com : MonoBehaviour
{
    public Slider com_hp; // ��ǻ���� ü���� ǥ���ϴ� �����̴�
    public Animator otherAnimator; // �ٸ� �ִϸ�����
    public Text scoretext; // ������ ǥ���ϴ� �ؽ�Ʈ
    public int currentscore; // ���� ����
    public bool showQuestionMark = true; // ����ǥ ǥ�� ����

    private float maxhp = 100; // �ִ� ü��
    private float curhp = 100; // ���� ü��

    private void Awake()
    {
    }

    void Start()
    {
        com_hp.value = (float)curhp / (float)maxhp; // ���� ü���� �����̴��� �ݿ�

        currentscore = 0; // ���� ���� �ʱ�ȭ
        UpdateScoreText(); // ���� �ؽ�Ʈ ������Ʈ
    }

    void Update()
    {
        if (curhp <= 0)
        {
            ResetHealth(); // ü�� �ʱ�ȭ
            showQuestionMark = false; // ����ǥ ǥ�ø� ��Ȱ��ȭ
            currentscore++; // ���� ����
            UpdateScoreText(); // ���� �ؽ�Ʈ ������Ʈ
        }
        else
        {
            com_hp.value = curhp / maxhp; // ���� ü���� �����̴��� �ݿ�
        }
    }

    public void ResetHealth()
    {
        curhp = maxhp; // ü���� �ִ� ü������ �ʱ�ȭ
    }

    public void UpdateScoreText()
    {
        if (showQuestionMark)
        {
            scoretext.text = "1 �� ? �� ����"; // ����ǥ�� ǥ���ϴ� ���
        }
        else
        {
            scoretext.text = "1 �� " + currentscore.ToString() + " �� ����"; // ���� ������ ǥ���ϴ� ���
        }
    }

    public void Attack(float amount)
    {
        otherAnimator.SetTrigger("Attack"); // ���� �ִϸ��̼��� ���
        curhp -= amount; // ���� ü�� ����
        curhp = Mathf.Clamp(curhp, 0, maxhp); // ���� ü���� �ִ� ü���� ���� �ʵ��� ����
    }
}
