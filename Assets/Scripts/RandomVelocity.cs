using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocity : MonoBehaviour
{
    // The Rigidbody2D component of the particle
    private Rigidbody2D rb2D;

    // Minimum and maximum speed for the random velocity
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    private void Start()
    {
        // Get the Rigidbody2D component attached to this particle
        rb2D = GetComponent<Rigidbody2D>();

        if (rb2D != null)
        {
            // Assign a random velocity
            SetRandomVelocity();
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found on this particle!");
        }
    }

    // Method to set a random velocity
    public void SetRandomVelocity()
    {
        // Generate a random direction (unit vector)
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Generate a random speed within the specified range
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Set the Rigidbody2D's velocity
        rb2D.velocity = randomDirection * randomSpeed;
    }
}