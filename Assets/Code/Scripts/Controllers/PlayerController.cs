using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vaisseauSpeed;
    public bool controlWithMouse;

    private float realVaisseauSpeed;
    private float boostTimeRemaining = 0f;
    private float timeInterval = .1f;



    // Start is called before the first frame update
    void Start()
    {
        realVaisseauSpeed = vaisseauSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Movements
        if (controlWithMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
        } else
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * vaisseauSpeed);

            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * vertical * Time.deltaTime * vaisseauSpeed);
        }

        if (boostTimeRemaining != 0f)
        {
            boostTimeRemaining -= timeInterval;
            realVaisseauSpeed = vaisseauSpeed * 2;
        } else
        {
            realVaisseauSpeed = vaisseauSpeed;
        }
    }

    public void boost()
    {
        Debug.Log("BOOST");
        boostTimeRemaining = 3f;
    }

    public void destruct()
    {
        GameObject sceneManager = GameObject.Find("SceneManager");
        SceneManagement manager;

        if (sceneManager != null && gameObject != null)
        {
            manager = sceneManager.GetComponent<SceneManagement>();
            if (manager.getLifePoints() > 1)
            {
                manager.decreaseLifePoints();
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
