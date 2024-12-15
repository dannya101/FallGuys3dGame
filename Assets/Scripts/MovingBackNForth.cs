using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public Transform pointA; // Reference to an empty GameObject for position A
    public Transform pointB; // Reference to an empty GameObject for position B
    public float speed = 1.0f; // Movement speed
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Use FixedUpdate for physics calculations
    {
        if (pointA != null && pointB != null && rb != null) // Ensure everything is assigned
        {
            // PingPong oscillates between 0 and 1
            float t = Mathf.PingPong(Time.time * speed, 1);
            // Lerp between the positions of the two empty GameObjects
            Vector3 targetPosition = Vector3.Lerp(pointA.position, pointB.position, t);
            // Move the Rigidbody to the target position
            rb.MovePosition(targetPosition);
        }
    }
}
