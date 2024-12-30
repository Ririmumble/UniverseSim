using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrostaticForce : MonoBehaviour
{
    // Charge of the particle (positive for protons, negative for electrons)
    public float charge = 1.0f;

    // Static list to keep track of all particles
    private static List<ElectrostaticForce> allParticles = new List<ElectrostaticForce>();

    // Rigidbody2D for applying forces
    private Rigidbody2D rb2D;

    // Coulomb's constant (in vacuum)
    //private const float k = 8.9875517923e9f;
    private const float k = 10;
    private void Awake()
    {
        // Add this particle to the list of all particles
        allParticles.Add(this);

        // Get the Rigidbody2D component
        rb2D = GetComponent<Rigidbody2D>();

        if (rb2D == null)
        {
            Debug.LogError("No Rigidbody2D found on this object. A Rigidbody2D is required for force application.");
        }
    }

    private void OnDestroy()
    {
        // Remove this particle from the list when destroyed
        allParticles.Remove(this);
    }

    private void FixedUpdate()
    {
        // Calculate and apply the net force on this particle due to all other particles
        CalculateCoulombsForce();
    }

    private void CalculateCoulombsForce()
    {
        // Initialize the net force
        Vector2 netForce = Vector2.zero;

        foreach (var other in allParticles)
        {
            // Skip self-interaction
            if (other == this) continue;

            // Calculate the vector between the two particles
            Vector2 direction = other.transform.position - transform.position;
            float distance = direction.magnitude;

            // Avoid division by zero or extremely small distances
            if (distance < 0.01f) continue;

            // Normalize the direction vector
            direction.Normalize();

            // Calculate the force magnitude using Coulomb's law
            float forceMagnitude = k * (charge * other.charge) / (distance * distance);

            // Calculate the force vector
            Vector2 force = -direction.normalized * forceMagnitude;

            // Add to the net force
            netForce += force;
        }
        // Apply the net force to the Rigidbody2D
        rb2D.AddForce(netForce);
    }
}