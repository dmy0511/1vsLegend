using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex05 : MonoBehaviour
{
    private com comScript;
    private user userScript;

    private bool isInsideBox = false;

    private void Start()
    {
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false;
        }
    }

    private void Update()
    {
        if (isInsideBox && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Collider2D itemCollider = GetComponent<Collider2D>();
            Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.red)
                {
                    comScript.Attack(10);
                }

                Destroy(gameObject);
            }
            else
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
            }
        }
    }
}
