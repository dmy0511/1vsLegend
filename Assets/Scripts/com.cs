using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com : MonoBehaviour
{
    public Slider com_hp; // 컴퓨터의 체력을 표시하는 슬라이더
    private Animator animator; // 애니메이터
    public Animator otherAnimator; // 애니메이터
    public Text scoretext; // 점수를 표시하는 텍스트
    public int currentscore; // 현재 점수
    public bool showQuestionMark = true; // 물음표 표시 여부
 
    private float maxhp = 100; // 최대 체력
    private float curhp = 100; // 현재 체력

    public Text G_text;
    public int G=0;
        
    private void Awake()
    {
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    }

    void Start()
    {
        G_text.text = G.ToString();
        com_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영

        currentscore = 0; // 현재 점수 초기화
        UpdateScoreText(); // 점수 텍스트 업데이트
    }


    void Update()
    {
        if (curhp <= 0)
        {
            ResetHealth(); // 체력 초기화
            showQuestionMark = false; // 물음표 표시를 비활성화
            currentscore++; // 점수 증가
            G += 100;
            G_text.text = G.ToString();
            
   
            UpdateScoreText(); // 점수 텍스트 업데이트
        }
        else
        {
            com_hp.value = curhp / maxhp; // 현재 체력을 슬라이더에 반영
        }
    }

    public void ResetHealth()
    {
        curhp = maxhp; // 체력을 최대 체력으로 초기화
    }

    public void UpdateScoreText()
    {
        if (showQuestionMark)
        {
            scoretext.text = "1 대 ? 의 전설"; // 물음표를 표시하는 경우
        }
        else
        {
            scoretext.text = "1 대 " + currentscore.ToString() + " 의 전설"; // 현재 점수를 표시하는 경우
        }
    }

    public void Attack(float amount)
    {
        otherAnimator.SetTrigger("Attack"); // 공격 애니메이션을 재생
        curhp -= amount; // 현재 체력 감소
        curhp = Mathf.Clamp(curhp, 0, maxhp); // 현재 체력이 최대 체력을 넘지 않도록 제한
    }
}
