using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputFieldExercise : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text text;

    private void Awake()
    {
        inputField.onValueChanged.AddListener(OnValueChangedEvent);
        inputField.onEndEdit.AddListener(OnEndEditEvent);
        inputField.onSubmit.AddListener(OnSubmit);
    }

    public void OnValueChangedEvent(string str)
    {
        text.text = $"닉네임(설정중) : {str}";
    }

    public void OnEndEditEvent(string str)
    {
        text.text = $"닉네임(설정완료) : {str}";
    }

    public void OnSubmit(string str)
    {
        PlayerPrefs.SetString("Nickname", str);
        SceneManager.LoadScene("SampleScene");
    }
}
