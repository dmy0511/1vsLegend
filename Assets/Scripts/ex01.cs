using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex01 : MonoBehaviour
{
    private float currentSpeed = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * currentSpeed;
    }
}

