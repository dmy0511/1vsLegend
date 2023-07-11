using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserMoving : MonoBehaviour
{
    public float normalSpeed = 1f;
    public float currentSpeed;

    public string nextSceneName;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void FixedUpdate()
    {   // 자동으로 왼쪽에서 오른쪽으로 이동
        Vector3 movement = new Vector3(-currentSpeed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed += 1f;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, normalSpeed, float.MaxValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            normalSpeed = 0;
        }
    }
}