using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject player;

    private Scene currentScene;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (currentScene.name == "Game" && player == null)
        {
            Debug.Log("OK");
            gameOver(0);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Scene Loaded: " + scene.name);
        Debug.Log("Scene Mode    : " + mode);
    }

    public void exitGame()
    {
        Debug.Log("Game exit... See you :)");
        Application.Quit();
    }

    public void play()
    {
        Debug.Log("go to game");
        SceneManager.LoadScene("Game");
    }

    public void gameOver(int points)
    {
        Debug.Log("You made: " + points + " points");
        Debug.Log("go to restart");
        SceneManager.LoadScene("Restart");
    }
}
