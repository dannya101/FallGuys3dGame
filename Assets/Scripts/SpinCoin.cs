using UnityEngine;

public class SpinCoin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
