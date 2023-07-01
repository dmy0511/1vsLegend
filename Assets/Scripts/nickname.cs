using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nickname : MonoBehaviour
{
    [SerializeField]
    private Text nicknameText; // �г����� ǥ���ϴ� �ؽ�Ʈ

    private void Start()
    {
        if (PlayerPrefs.HasKey("Nickname"))
        {
            string nickname = PlayerPrefs.GetString("Nickname"); // ����� �г��� ��������
            nicknameText.text = nickname; // �г����� �ؽ�Ʈ�� �ݿ�
        }
        else
        {
            nicknameText.text = "???"; // ����� �г����� ���� ��� "???"���� ǥ��
        }
    }
}

