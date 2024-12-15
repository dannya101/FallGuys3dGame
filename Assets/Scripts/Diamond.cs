using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public int scoreValue = 50; // Amount to increase the score
    public AudioClip collectSound; // Sound to play when collected
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Add an AudioSource component if one isn't already attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the diamond around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player can collect the diamond
        {
            // Play the collection sound
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Increase the score or time
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.AddTime(scoreValue); // Add time to the timer
            }

            // Destroy the diamond after the sound has finished playing
            Destroy(gameObject, collectSound.length);
        }
    }
}
