using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com : MonoBehaviour
{
    public Slider com_hp;

    private float maxhp = 100;
    private float curhp = 100;

    void Start()
    {
        com_hp.value = (float)curhp / (float)maxhp;
    }

    void Update()
    {
        HandleHp();
    }

    private void HandleHp()
    {
        com_hp.value = (float)curhp / (float)maxhp;
    }

    public void nice()
    {
        curhp -= 10;
    }
}
