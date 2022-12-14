using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public AudioSource audioSource;

    private GameObject player;
    private Scene currentScene;
    private int score;
    private int lastRecord;
    private int lifePoints;

    void Start()
    {
        player = GameObject.Find("Vaisseau");
        currentScene = SceneManager.GetActiveScene();
        score = 0;
        lifePoints = 3;
        lastRecord = PlayerPrefs.GetInt("LastRecord", 0);
        Debug.Log("lr:" + lastRecord);

        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (currentScene.name == "Restart")
        {
            score = PlayerPrefs.GetInt("LastGameScore", 0);
            Debug.Log("You made: " + score + " points");
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
        PlayerPrefs.SetInt("LastGameScore", score);

        if (lastRecord < score)
        {
            PlayerPrefs.SetInt("LastRecord", score);
        }

        SceneManager.LoadScene("Restart", LoadSceneMode.Single);
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

    public int getLastRecord()
    {
        return lastRecord;
    }

    public int getLifePoints()
    {
        return lifePoints;
    }

    public void decreaseLifePoints()
    {
        lifePoints -= 1;
    }

    public void increaseLifePoints()
    {
        lifePoints += 1;
    }
}
