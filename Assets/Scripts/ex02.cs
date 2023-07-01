using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex02 : MonoBehaviour
{
    private com comScript;
    private user userScript;
    private TimerBar timerScript;

    private bool isInsideBox = false; // 상자 안에 있는지 여부
    private bool BoxCenter = false; // 상자 중앙에 있는지 여부

    private float moveSpeed = 5f; // 이동 속도
    private float wait_time = 3f; // 대기 시간
    private float minus_time = 0f; // 시간 감소

    private void Start()
    {
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
        timerScript = FindObjectOfType<TimerBar>();
    }

    private void waiting()
    {
        // 키 이동 여부를 true로 설정하여 대기 종료
        GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true; // 상자 안에 들어감
        }
        else if (collision.CompareTag("Center"))
        {
            // 키 이동 여부를 false로 설정하여 대기 시작
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = false;
            Invoke("waiting", wait_time - minus_time); // 지정된 대기 시간 이후에 waiting 함수 호출
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false; // 상자에서 나옴
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false; // 중앙에서 나옴
        }
    }

    private void Update()
    {
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
        {
            // 오브젝트가 상자 안에 있으므로 이동을 멈춤
            // 오브젝트가 상자 안에 있을 때 추가적인 코드를 넣을 수 있음
        }
        else
        {
            // 오브젝트가 상자 안에 없으므로 왼쪽에서 오른쪽으로 일정한 속도로 이동
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.red)
                {
                    comScript.Attack(25);
                }

                Destroy(gameObject);
                timerScript.OnDestroy();
            }
        }
        else if (isInsideBox && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.red)
                {
                    userScript.DefenseFail(10);
                }
                else if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
                timerScript.OnDestroy();
            }
        }
    }
}
