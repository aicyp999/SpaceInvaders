using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastRecord : MonoBehaviour
{
    private int lastRecord;
    private Text uiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");
        uiScoreText = GetComponent<Text>();

        if (sceneManager != null && uiScoreText != null)
        {
            lastRecord = sceneManager.GetComponent<SceneManagement>().getLastRecord();
            uiScoreText.text = "<YOUR RECORD IS> " + lastRecord + " <POINTS>";
        } else
        {
            uiScoreText.text = "we lost your last record... weird...";
        }
        
    }
}
