using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;  // Speed for smooth rotation
    [SerializeField] private float jumpForce = 7f;       // Force applied when jumping
    [SerializeField] private LayerMask groundLayer;      // Layer to check if the player is grounded
    private Rigidbody rb;
    private Vector3 movementDirection;  // Direction vector for movement
    private bool isGrounded;
    [SerializeField] private Animator[] _animation;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is grounded
        GroundCheck();
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
        Debug.Log("Player jumps!");
        // Add jump logic
        if (isGrounded)  // Only jump if the player is grounded
        {
            // Apply an upward force to the player
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // Prevent double jumping
            Debug.Log("Player jumps!");
        }
    }

    public void Attack()
    {
        Debug.Log("Player attacks!");
        // Add attack logic
        _animation[0].SetTrigger("Slash");
    }

    public void Defend()
    {
        Debug.Log("Player defends!");
        // Add defend logic
        _animation[1].SetTrigger("Defend");
    }
    
    private void GroundCheck()
    {
        // Perform a raycast downwards to check if the player is grounded
        RaycastHit hit;
        float rayDistance = 1.1f;  // Adjust based on the height of your player
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, groundLayer))
        {
            isGrounded = true;  // Set the player as grounded if the ray hits the ground
        }
        else
        {
            isGrounded = false;  // Not grounded if no ground is detected
        }
    }
}
