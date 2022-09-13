using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score;
    private Text uiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");
        uiScoreText = GetComponent<Text>();

        if (sceneManager != null && uiScoreText != null)
        {
            score = sceneManager.GetComponent<SceneManagement>().getScore();
            uiScoreText.text = "last score: " + score;
        } else
        {
            uiScoreText.text = "we lost the score... weird...";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
