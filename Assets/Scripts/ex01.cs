using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex01 : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
}

