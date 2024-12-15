using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float delayTime = 3f;  // Time in seconds before transitioning to the next scene

    void Start()
    {
        // Optionally, you can call this automatically when the script starts or at any event
        Invoke("LoadNextScene", delayTime);
    }

    public void LoadNextScene()
    {
        // Unload the current scene (optional)
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        // Load the next scene (scene at index 5 or use a name)
        SceneManager.LoadScene(5);
    }
}
