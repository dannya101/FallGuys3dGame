using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10;  // Amount to increase the score
    public AudioClip pickupSound; // Sound to play on pickup
    private AudioSource audioSource; // Reference to the Audio Source

    private void Start()
    {
        // Get the Audio Source component attached to the coin
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the coin! Add one in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure only the player can collect the coin
        {
            // Increase the score or time
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.AddTime(scoreValue);  // Add time to the timer
            }

            // Play the pickup sound
            if (audioSource != null && pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound); // Play the sound
            }

            // Delay the destruction slightly to allow the sound to play
            Destroy(gameObject, 0.2f); // Adjust delay as needed
        }
    }
}