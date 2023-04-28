using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     [Range(0, 10)]
        [SerializeField] private float speed = 6f;
        [SerializeField] private float JumpHeight = 10f;
        private bool isJumping;
        private Rigidbody2D rb;
        private BoxCollider2D bc;
        private Vector2 movement;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            bc = GetComponent<BoxCollider2D>();
            // isJumping = false;
        }
        
        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown("space") && !isJumping)
            {
                Debug.Log("jump");
                rb.AddForce(Vector2.up * JumpHeight * speed, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            isJumping = false;
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
}
