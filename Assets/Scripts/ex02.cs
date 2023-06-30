using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex02 : MonoBehaviour
{
    private com comScript;
    private user userScript;

    private bool isInsideBox = false;
    private bool BoxCenter = false;

    private float moveSpeed = 5f;

    private void Start()
    {
        // comScript와 userScript를 해당 타입의 인스턴스를 찾아 할당합니다.
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 태그가 "Box"인 경우, isInsideBox를 true로 설정
        // 충돌한 오브젝트의 태그가 "Center"인 경우, BoxCenter를 true로 설정
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true;
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 태그가 "Box"인 경우, isInsideBox를 false로 설정
        // 충돌한 오브젝트의 태그가 "Center"인 경우, BoxCenter를 false로 설정
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false;
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false;
        }
    }

    private void Update()
    {
        // 현재 오브젝트의 Collider2D 컴포넌트와 Box의 Collider2D 컴포넌트를 가져옴
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        Renderer renderer = GetComponent<Renderer>();

        if (BoxCenter)
        {
            // 오브젝트가 센터에 있으면 이동 X

            Destroy(gameObject, 3f);

            if (renderer.material.color == Color.blue)
            {
                userScript.DefenseFail(10);
            }
        }
        else
        {
            // 오브젝트가 센터 안에 없으면 일정한 속도로 오른쪽으로 이동
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 아이템 Collider가 상자 Collider 내에 포함되는지 확인
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {

                if (renderer.material.color == Color.red)
                {
                    comScript.Attack(25);
                }

                Destroy(gameObject);
            }
        }
        else if (isInsideBox && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            // 아이템 Collider가 상자 Collider 내에 포함되는지 확인
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {

                if (renderer.material.color == Color.red)
                {
                    userScript.DefenseFail(10);
                }
                else if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
            }
        }
    }
}
