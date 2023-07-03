using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputFieldExercise : MonoBehaviour
{
    [SerializeField]
    private InputField inputField; // 입력 필드
    [SerializeField]
    private Text text; // 텍스트

    private void Awake()
    {
        inputField.onValueChanged.AddListener(OnValueChangedEvent); // 값 변경 이벤트에 대한 리스너 추가
        inputField.onEndEdit.AddListener(OnEndEditEvent); // 편집 종료 이벤트에 대한 리스너 추가
        inputField.onSubmit.AddListener(OnSubmit); // 제출 이벤트에 대한 리스너 추가
    }

    public void OnValueChangedEvent(string str)
    {
        text.text = $"닉네임(설정중) : {str}"; // 텍스트 업데이트: 닉네임(설정중) : {입력값}
    }

    public void OnEndEditEvent(string str)
    {
        text.text = $"닉네임(설정완료) : {str}"; // 텍스트 업데이트: 닉네임(설정완료) : {입력값}
    }

    public void OnSubmit(string str)
    {
        PlayerPrefs.SetString("Nickname", str); // 입력값을 PlayerPrefs에 저장
        SceneManager.LoadScene("NormalPlay"); // NormalPlay Scene으로 이동
    }
}
