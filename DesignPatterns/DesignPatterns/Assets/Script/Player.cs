using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;  // Speed for smooth rotation
    [SerializeField] private float jumpForce = 7f;       // Force applied when jumping
    private Rigidbody rb;
    private Vector3 movementDirection;  // Direction vector for movement
    [SerializeField]private bool isGrounded;
    [SerializeField] private Animator _animation;
    [SerializeField] private Animator shieldAni;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Walk(Vector3 direction)
    {
        if (direction.magnitude > 0)  // Check if there's any movement
        {
            // Normalize the direction to ensure consistent movement speed
            movementDirection = direction.normalized;

            // Move the player using Rigidbody physics
            rb.MovePosition(rb.position + movementDirection * walkSpeed * Time.deltaTime);

            // Rotate the player smoothly towards the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
    }

    public void Jump()
    {
        if (isGrounded)  // Only jump if the player is grounded
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("Player jumps!");
        }
    }

    public void Attack()
    {
        Debug.Log("Player attacks!");
        _animation.SetTrigger("Slash");
    }

    public void Defend()
    {
        Debug.Log("Player defends!");
        shieldAni.SetTrigger("Defend");
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    
}
