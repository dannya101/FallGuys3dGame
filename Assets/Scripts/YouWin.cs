using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public AudioClip winSound; // Sound to play when the player wins
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
    }

    // Method to load the win screen scene
    public void Win()
    {
        SceneManager.LoadScene(0); // Change this if needed to another scene
    }

    // Collision detection for 3D
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.CompareTag("Player")) // Check if the collided object is the player
        {
            // Play the win sound
            if (winSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            Time.timeScale = 0f; // Pause the game (optional)

            // Delay loading the scene to allow the sound to play
            StartCoroutine(LoadSceneAfterSound());
        }
    }

    private IEnumerator LoadSceneAfterSound()
    {
        if (winSound != null)
        {
            yield return new WaitForSecondsRealtime(winSound.length); // Wait for the sound to finish
        }
        SceneManager.LoadScene(3); // Load the winning screen scene
    }
}
