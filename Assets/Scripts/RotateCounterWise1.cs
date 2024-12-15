using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArm : MonoBehaviour
{
    public GameObject objectToRotate; // The object to rotate
    private Rigidbody rb;

    public float rotationSpeed = 30f; // Constant rotation speed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on the object to rotate!");
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Calculate the new rotation
            Quaternion targetRotation = Quaternion.Euler(
                objectToRotate.transform.eulerAngles.x,
                objectToRotate.transform.eulerAngles.y + rotationSpeed * Time.fixedDeltaTime,
                objectToRotate.transform.eulerAngles.z
            );

            // Apply rotation using Rigidbody
            rb.MoveRotation(targetRotation);
        }
    }
}
