using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDestruction : MonoBehaviour
{

    private int numberOfHits = 1;

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
        
        if (canBeHit())
        {
            GameObject sceneManager = GameObject.Find("SceneManager");

            if (sceneManager != null && gameObject != null)
            {
                sceneManager.GetComponent<SceneManagement>().incrementScore();
            }

            Destroy(gameObject);
        }
    }

    // To avoid multiple collisions at the same time
    private bool canBeHit()
    {
        numberOfHits--;
        return numberOfHits >= 0;
    }
}
