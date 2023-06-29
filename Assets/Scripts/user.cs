using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user : MonoBehaviour
{
    public Slider user_hp;
    private Animator animator;

    private float maxhp = 100;
    private float curhp = 100;

    private com comScript;

    private void Awake()
    {
        comScript = FindObjectOfType<com>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        user_hp.value = (float)curhp / (float)maxhp;
    }

    void Update()
    {
        HandleHp();

        if (curhp <= 0)
        {
            string savedData = comScript.scoretext.text;

            GameObject bestTextObject = GameObject.Find("BestText");
            if (bestTextObject != null)
            {
                Text bestText = bestTextObject.GetComponent<Text>();
                if (bestText != null)
                {
                    bestText.text = savedData;
                }
            }

            comScript.ResetHealth();
            comScript.showQuestionMark = false;
            comScript.UpdateScoreText();
        }
        else
        {
            user_hp.value = curhp / maxhp;
        }
    }

    private void HandleHp()
    {
        user_hp.value = (float)curhp / (float)maxhp;
    }

    public void DefenseFail(float amount)
    {
        curhp -= amount;
        curhp = Mathf.Clamp(curhp, 0, maxhp);
    }
}
