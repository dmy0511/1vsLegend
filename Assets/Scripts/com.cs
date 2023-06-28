using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com : MonoBehaviour
{
    public Slider com_hp;

    public Text scoretext;
    private int currentscore;
    private bool showQuestionMark = true;

    private float maxhp = 100;
    private float curhp = 100;

    void Start()
    {
        com_hp.value = (float)curhp / (float)maxhp;

        currentscore = 0;
        UpdateScoreText();
    }

    void Update()
    {
        if (curhp <= 0)
        {
            ResetHealth();
            showQuestionMark = false;
            currentscore++;
            UpdateScoreText();
        }
        else
        {
            com_hp.value = curhp / maxhp;
        }
    }

    private void ResetHealth()
    {
        curhp = maxhp;
    }

    void UpdateScoreText()
    {
        if (showQuestionMark)
        {
            scoretext.text = "1 대 ? 의 전설";
        }
        else
        {
            scoretext.text = "1 대 " + currentscore.ToString() + " 의 전설";
        }
    }

    public void Attack(float amount)
    {
        curhp -= amount;
        curhp = Mathf.Clamp(curhp, 0, maxhp);
    }
}
