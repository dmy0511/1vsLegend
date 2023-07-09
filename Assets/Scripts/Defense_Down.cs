using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Down : MonoBehaviour
{
    private com comScript;
    private user userScript;
    private TimerBar timerScript;

    private bool isInsideBox = false;
    private bool BoxCenter = false;

    private float moveSpeed = 20f;
    private float wait_time = 0.5f;
    private float minus_time = 0f;

    //public void time_down_func()
    //{
    //    for (int i = 0; i <= GameObject.Find("Center").GetComponent<TimerBar>().time_down_count; i += 5)
    //    {
    //        if (wait_time >= 1f || moveSpeed>=3.5f || GameObject.Find("Spawner").GetComponent<spawner>().currentCoolTime<= 0.25f)
    //        {
    //            minus_time += 0.2f;
    //        }
    //        else
    //        {
                
    //        }
    //    }
    //}

    private void Start()
    {
        wait_time = 3f;

        //time_down_func();
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
        timerScript = FindObjectOfType<TimerBar>();
    }

    private void waiting()
    {
        Destroy(gameObject);
        userScript.DefenseFail(10);

        GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true;
        }
        else if (collision.CompareTag("Center"))
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = false;
            Invoke("waiting", wait_time - minus_time);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false;
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
        {

        }
        else
        {
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;

            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                // �ִϸ��̼� ����

                Destroy(gameObject);
                timerScript.OnDestroy();
            }
        }
        else if (isInsideBox && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;

            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                //int at = 10;
                //for (int i = 0; i <   GameObject.Find("Center").GetComponent<TimerBar>().time_down_count; i+=3)
                //{
                //    at++;
                //}
                userScript.DefenseFail(10);

                Destroy(gameObject);
                timerScript.OnDestroy();
            }
        }
    }
}
