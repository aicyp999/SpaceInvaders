using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnClick : MonoBehaviour
{
    public GameObject bullet;

    private bool isBoosted;
    private int bonusShoot;

    // Start is called before the first frame update
    void Start()
    {
        isBoosted = false;
        bonusShoot = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) && !isBoosted)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) && isBoosted)
        {
            for (int i = 1; i <= bonusShoot; i++)
            {
                Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(i * 45, Vector3.up));
            }
        }
    }

    public void fireBoost()
    {
        isBoosted = true;
        bonusShoot++;
    }

    public void stopFireBoost()
    {
        isBoosted = false;
        bonusShoot = 1;
    }
}
