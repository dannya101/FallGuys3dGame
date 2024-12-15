using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public Text timerText;  // UI Text to display the time
    private float timeElapsed = 0f;  // Tracks time
    private bool isAlive = true;  // Tracks if the player is alive

    void Update()
    {
        if (isAlive)
        {
            timeElapsed += Time.deltaTime;  // Increment time
            UpdateTimerDisplay();
            if(GetScore() >= 100)
                GetToLevelTwo();
            
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = Mathf.FloorToInt(timeElapsed).ToString();  // Display seconds as score
    }

    public void StopTimer()
    {
        isAlive = false;  // Stops the timer when the player dies
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(timeElapsed);  // Returns the score
    }

    public void AddTime(int amount)
    {
        timeElapsed += amount;  // Increase the timer
        UpdateTimerDisplay();
    }

    public void GetToLevelTwo()
    {
        SceneManager.LoadScene(4);
    }
}
