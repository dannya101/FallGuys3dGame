using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class RotatingClockWise : MonoBehaviour
{
    public GameObject objectToRotate;
    private Quaternion targetRotation;
    private float speed = 10f; // Initial speed
    private float timer = 0f;
    private float tolerance = 0.01f; // Define a small tolerance
    public Rigidbody rb;
    private bool rotateClockwise = true;
    private float acceleration = 2f; // How much the speed increases per second
    private float maxSpeed = 100f; // Maximum spe
    public float knockbackForce = 5f; // Force applied to the player on collision

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            {
                Debug.LogError("Rigidbody is missing on the object to rotate!");
            }
        else
            {
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= 5f) // Every 5 seconds
        {
            timer = 0f; // Reset timer
            rotateClockwise = !rotateClockwise; // Toggle rotation direction
        }

        // Increase the speed linearly but cap it at maxSpeed
        speed = Mathf.Min(speed + acceleration * Time.fixedDeltaTime, maxSpeed);

        // Determine the rotation direction
        float rotationSpeed = rotateClockwise ? speed : -speed;

        Debug.Log("Speed: " + rotationSpeed);

        if (rb != null)
        {
            // Calculate the new rotation
            Quaternion targetRotation = Quaternion.Euler(
                objectToRotate.transform.eulerAngles.x,
                objectToRotate.transform.eulerAngles.y - rotationSpeed * Time.fixedDeltaTime,
                objectToRotate.transform.eulerAngles.z
            );

            // Apply rotation using Rigidbody
            rb.MoveRotation(targetRotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Determine the collision point relative to the arm's position
            Vector3 collisionDirection = collision.contacts[0].point - transform.position;

            // Check if the collision is from the side (not the top)
            if (Mathf.Abs(collisionDirection.y) < 0.5f) // Adjust this threshold as needed
            {
                Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    // Calculate knockback direction and apply force
                    Vector3 knockbackDirection = collisionDirection.normalized;
                    knockbackDirection.y = 0.2f; // Slight upward force for knockback
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
