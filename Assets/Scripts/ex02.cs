using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex02 : MonoBehaviour
{
    private com comScript;
    private user userScript;
    private TimerBar timerScript;

    private bool isInsideBox = false; // ���� �ȿ� �ִ��� ����
    private bool BoxCenter = false; // ���� �߾ӿ� �ִ��� ����

    private float moveSpeed = 5f; // �̵� �ӵ�
    private float wait_time = 3f; // ��� �ð�
    private float minus_time = 0f; // �ð� ����

    private void Start()
    {
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
        timerScript = FindObjectOfType<TimerBar>();
    }

    private void waiting()
    {
        // Ű �̵� ���θ� true�� �����Ͽ� ��� ����
        GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true; // ���� �ȿ� ��
        }
        else if (collision.CompareTag("Center"))
        {
            // Ű �̵� ���θ� false�� �����Ͽ� ��� ����
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = false;
            Invoke("waiting", wait_time - minus_time); // ������ ��� �ð� ���Ŀ� waiting �Լ� ȣ��
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false; // ���ڿ��� ����
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false; // �߾ӿ��� ����
        }
    }

    private void Update()
    {
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
        {
            // ������Ʈ�� ���� �ȿ� �����Ƿ� �̵��� ����
            // ������Ʈ�� ���� �ȿ� ���� �� �߰����� �ڵ带 ���� �� ����
        }
        else
        {
            // ������Ʈ�� ���� �ȿ� �����Ƿ� ���ʿ��� ���������� ������ �ӵ��� �̵�
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.UpArrow))
        {
                     GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
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

                           GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
             
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
