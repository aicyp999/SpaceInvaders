using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private GameObject player;
    private Scene currentScene;
    private int score;

    void Start()
    {
        player = GameObject.Find("Vaisseau");
        currentScene = SceneManager.GetActiveScene();
        score = 0;

        if (currentScene.name == "Restart")
        {
            // TODO: Get the last game's score
        }
    }

    void Update()
    {
        if (currentScene.name == "Game" && player == null)
        {
            gameOver();
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
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void gameOver()
    {
        Debug.Log("You made: " + score + " points");
        SceneManager.LoadScene("Restart", LoadSceneMode.Additive);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void incrementScore()
    {
        Debug.Log("score is :" + score);
        score += 1;
    }

    public int getScore()
    {
        return score;
    }
}
