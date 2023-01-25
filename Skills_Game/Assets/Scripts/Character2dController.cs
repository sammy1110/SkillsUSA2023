using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2dController : MonoBehaviour
{
    public float MovementSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }






}
