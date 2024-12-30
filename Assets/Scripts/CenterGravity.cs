using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGravity : MonoBehaviour
{
    public float gravitationalConstant = 100f; // Adjust based on your game's scale
    private Rigidbody2D[] celestialBodies;
    void Start()
    {
        // Find all objects with Rigidbody2D in the scene
        celestialBodies = FindObjectsOfType<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyGravitationalForces();
    }

    void ApplyGravitationalForces()
    {
        // Loop through each pair of celestial bodies
        foreach (var bodyA in celestialBodies)
        {
            // Calculate the direction and distance between the two bodies
            Vector2 direction = Vector2.zero - bodyA.position;
            float distance = direction.magnitude;
            // Avoid division by zero and extremely small distances
            if (distance <= 0.01f) continue;

            // Calculate gravitational force magnitude
            float forceMagnitude = gravitationalConstant * (bodyA.mass * 1) / (distance * distance);
            // Calculate the force vector
            Vector2 force = direction.normalized * forceMagnitude;
            // Apply the force to bodyA
            bodyA.AddForce(force);
            
        }
    }
}