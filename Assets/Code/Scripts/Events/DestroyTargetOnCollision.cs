using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class DestroyTargetOnCollision : MonoBehaviour
{
    public string[] targets;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && Array.IndexOf(targets, other.tag) > -1)
        {
            if (gameObject.tag != "Collider")
            {
                if (other.tag == "Boost")
                {
                    GetComponent<PlayerController>().boost();

                    PlaySound("power");

                    Destroy(other.gameObject);
                }
                else if (other.tag == "Player" && gameObject.tag != "Collider")
                {
                    PlaySound("crash");

                    // Call the player's destruct method to manage some other options
                    if (other.gameObject.name == "Vaisseau")
                    {
                        other.gameObject.GetComponent<PlayerController>().destruct();
                    }
                    else
                    {
                        Destroy(other.gameObject);
                    }

                    if (gameObject.tag == "Enemy")
                    {
                        gameObject.GetComponent<OnEnemyDestruction>().destruct();
                    }

                    if (gameObject.tag == "Obstacle" && other.gameObject.name == "Vaisseau")
                    {
                        Destroy(gameObject);
                    }
                }
            }   
            else
            {
                if (gameObject.tag != "Collider")
                {
                    PlaySound("crash");
                }

                Destroy(other.gameObject);
            }
        }
    }

    private void PlaySound(string type)
    {
        GameObject crash = GameObject.Find("AudioCrash");
        GameObject powerUp = GameObject.Find("AudioPowerUp");

        switch (type)
        {
            case "crash":
                if (crash != null)
                {
                    crash.GetComponent<AudioSource>().Play();
                }
                break;
            case "power":
                if (crash != null)
                {
                    powerUp.GetComponent<AudioSource>().Play();
                }
                break;
            default:
                // do nothing
                Debug.Log("NOTHING");
                break;
        }
    }
}
