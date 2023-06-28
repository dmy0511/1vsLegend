using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user : MonoBehaviour
{
    public Slider user_hp;

    private float maxhp = 100;
    private float curhp = 100;

    void Start()
    {
        user_hp.value = (float)curhp / (float)maxhp;
    }

    void Update()
    {
        HandleHp();
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
