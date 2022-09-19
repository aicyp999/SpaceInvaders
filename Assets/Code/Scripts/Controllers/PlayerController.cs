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
    private GameObject gunL;
    private GameObject gunR;


    // Start is called before the first frame update
    void Start()
    {
        realVaisseauSpeed = vaisseauSpeed;
        gunL = gameObject.transform.GetChild(0).gameObject;
        gunR = gameObject.transform.GetChild(1).gameObject;
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
            if (gunL != null)
            {
                gunL.GetComponent<ShootOnClick>().stopFireBoost();
            }
            if (gunR != null)
            {
                gunR.GetComponent<ShootOnClick>().stopFireBoost();
            }
        }
    }

    public void boost()
    {
        Debug.Log("BOOST");
        boostTimeRemaining = 3f;

        if (gunL != null)
        {
            gunL.GetComponent<ShootOnClick>().fireBoost();
        }
        if (gunR != null)
        {
            gunR.GetComponent<ShootOnClick>().fireBoost();
        }
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
