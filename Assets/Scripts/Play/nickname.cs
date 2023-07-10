using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nickname : MonoBehaviour
{
    [SerializeField]
    private Text nicknameText; // 닉네임을 표시하는 텍스트

    private void Start()
    {
        if (PlayerPrefs.HasKey("Nickname"))
        {
            string nickname = PlayerPrefs.GetString("Nickname"); // 저장된 닉네임 가져오기
            nicknameText.text = nickname; // 닉네임을 텍스트에 반영
        }
        else
        {
            nicknameText.text = "???"; // 저장된 닉네임이 없는 경우 "???"으로 표시
        }
    }
}

