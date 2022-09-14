using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public bool inGame = false;

    private int score;
    private Text uiScoreText;
    private GameObject sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        uiScoreText = GetComponent<Text>();

        if (sceneManager != null && uiScoreText != null)
        {
            score = sceneManager.GetComponent<SceneManagement>().getScore();
            uiScoreText.text = inGame ? "<enemy destroyed: " + score + "/>" : "<YOUR SCORE IS> " + score + " <POINTS>";
        } else
        {
            uiScoreText.text = "we lost the score... weird...";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            if (sceneManager != null && uiScoreText != null)
            {
                score = sceneManager.GetComponent<SceneManagement>().getScore();
                uiScoreText.text = "<enemy destroyed: " + score + "/>";
            }
        }
    }
}
