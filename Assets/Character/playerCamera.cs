using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float distance = 5f; // Distance behind the player
    public float height = 2f; // Height above the player
    public float followSpeed = 10f; // Speed at which the camera follows
    public float rotationSpeed = 100f; // Speed at which the camera rotates

    private Vector3 offset;

    void Start()
    {
        // Set the initial offset based on the player's position
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        // Follow the player smoothly
        Vector3 targetPosition = player.position + player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate the camera based on mouse input
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Rotate the player and camera horizontally
        player.Rotate(0, horizontal, 0);

        // Adjust vertical camera rotation
        offset = Quaternion.AngleAxis(horizontal, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(vertical, transform.right) * offset;

        // Look at the player
        transform.LookAt(player.position + Vector3.up * height);
    }
}
