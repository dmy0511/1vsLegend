using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nickname : MonoBehaviour
{
    [SerializeField]
    private Text nicknameText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Nickname"))
        {
            string nickname = PlayerPrefs.GetString("Nickname");
            nicknameText.text = $"닉네임 : {nickname}";
        }
        else
        {
            nicknameText.text = "닉네임 : ???";
        }
    }
}

