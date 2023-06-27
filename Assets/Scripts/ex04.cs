    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex04 : MonoBehaviour
{
    private bool isInsideBox = false;

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
        if (isInsideBox && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Collider2D itemCollider = GetComponent<Collider2D>();
            Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Destroy(gameObject);
            }
        }
    }
}
