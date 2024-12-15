using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target; // The character the camera will follow
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset of the camera relative to the player
    public float smoothSpeed = 10f; // Speed of the camera smoothing

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned to the camera!");
            return;
        }

        // Calculate the desired position with the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}