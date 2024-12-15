using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerEndScene : MonoBehaviour
{
    // The neative Y position threshold
    [SerializeField] private float fallThreshold = -5f;

    // The positive Y position threshold
    [SerializeField] private float flyThreshold = 50f;

    // Name of the scene to load
    [SerializeField] private string endSceneName = "End Game";

    void Update()
    {
        // Check if the player's Y position is below the threshold
        if (transform.position.y <= fallThreshold || transform.position.y >= flyThreshold)
        {
            // Switch to the end scene
            SceneManager.LoadScene(endSceneName);
        }
    }
}