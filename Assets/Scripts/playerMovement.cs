using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed = 3f;
    Vector2 movement;
    Rigidbody2D rb;
    Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude * speed);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}