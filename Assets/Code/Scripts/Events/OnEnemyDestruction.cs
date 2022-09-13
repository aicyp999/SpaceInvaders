using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increment score and self destruct
    public void destruct()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");

        if (sceneManager != null && gameObject != null)
        {
            sceneManager.GetComponent<SceneManagement>().incrementScore();
        }

        Destroy(gameObject);
    }
}
