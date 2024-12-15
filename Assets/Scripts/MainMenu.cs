using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//cuz we start at 0, mainMenu, go to 1, actual game
    }

    public void Quit()
    {
        Application.Quit();//will quit the game
        Debug.Log("Player Has Quit");//just like a mechanic to add for just fun
    }
}