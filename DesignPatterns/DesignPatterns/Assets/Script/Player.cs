using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float walkSpeed = 5f;
    [SerializeField]private float jumpHeight;
    private Rigidbody rb;
    private Vector3 movementDirection;  // Direction vector for movement
    private Animation[] _animation;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Walk(Vector3 direction)
    {
        // Normalize the direction to ensure consistent movement speed
        movementDirection = direction.normalized;
        // Move the player using Rigidbody physics
        rb.MovePosition(rb.position + movementDirection * walkSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Player jumps!");
        // Add jump logic
    }

    public void Attack()
    {

        _animation[0].Play();
        Debug.Log("Player attacks!");
        // Add attack logic
        
    }

    public void Defend()
    {
        Debug.Log("Player defends!");
        // Add defend logic
    }
}
