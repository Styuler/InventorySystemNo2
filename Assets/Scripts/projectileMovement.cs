using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private float speed = 20f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.left * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("take that");
    }
}
