using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement1 : MonoBehaviour
{
    public Transform playerCamera; // Attach the camera here
    public float moveSpeed = 6f; // Movement speed
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float rotationSpeed = 2f; // Speed of rotation based on mouse movement
    public float cameraDistance = 5f; // Distance of the camera from the player

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate the player based on mouse input
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0, horizontalRotation, 0);

        // Move the camera vertically (up/down rotation)
        float verticalRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        playerCamera.Rotate(-verticalRotation, 0, 0);

        // Prevent camera from flipping by clamping its rotation
        Vector3 cameraEulerAngles = playerCamera.localEulerAngles;
        cameraEulerAngles.x = Mathf.Clamp(cameraEulerAngles.x, -45f, 45f); // Limit up/down tilt
        playerCamera.localEulerAngles = cameraEulerAngles;

        // Move the player
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = moveSpeed * Input.GetAxis("Vertical");
        float curSpeedY = moveSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // Update the camera's position to stay behind the player
        Vector3 cameraPosition = transform.position - transform.forward * cameraDistance + Vector3.up * 2f;
        playerCamera.position = cameraPosition;
        playerCamera.LookAt(transform.position + Vector3.up * 1.5f); // Keep the camera focused slightly above the player
    }
}
