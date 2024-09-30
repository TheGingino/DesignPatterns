using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Rigidbody rb;
    
    public void Walk(Vector3 direction)
    {
        Debug.Log("Player is walking");
        rb.MovePosition(transform.position + direction * (walkSpeed * Time.deltaTime));  // Verplaats de speler
    }
    
    public void Jump()
    {
        Debug.Log("Player jumps!");
        // Voeg hier logica voor springen toe, zoals het toepassen van een Rigidbody kracht
    }

    public void Attack()
    {
        Debug.Log("Player attacks!");
        // Voeg hier logica voor aanvallen toe, bijvoorbeeld animaties of schade toebrengen aan vijanden
    }

    public void Defend()
    {
        Debug.Log("Player defends!");
        // Voeg hier logica voor verdedigen toe, bijvoorbeeld een schild opzetten
    }
}
