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
        // comScript�� userScript�� �ش� Ÿ���� �ν��Ͻ��� ã�� �Ҵ��մϴ�.
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �±װ� "Box"�� ���, isInsideBox�� true�� ����
        // �浹�� ������Ʈ�� �±װ� "Center"�� ���, BoxCenter�� true�� ����
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
        // �浹�� ������Ʈ�� �±װ� "Box"�� ���, isInsideBox�� false�� ����
        // �浹�� ������Ʈ�� �±װ� "Center"�� ���, BoxCenter�� false�� ����
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
        // ���� ������Ʈ�� Collider2D ������Ʈ�� Box�� Collider2D ������Ʈ�� ������
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        Renderer renderer = GetComponent<Renderer>();

        if (BoxCenter)
        {
            // ������Ʈ�� ���Ϳ� ������ �̵� X

            Destroy(gameObject, 3f);

            if (renderer.material.color == Color.blue)
            {
                userScript.DefenseFail(10);
            }
        }
        else
        {
            // ������Ʈ�� ���� �ȿ� ������ ������ �ӵ��� ���������� �̵�
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // ������ Collider�� ���� Collider ���� ���ԵǴ��� Ȯ��
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
            // ������ Collider�� ���� Collider ���� ���ԵǴ��� Ȯ��
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
