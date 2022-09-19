using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class DestroyTargetOnCollision : MonoBehaviour
{
    public string[] targets;
    public AudioClip crashSound;
    public AudioClip powerSound;

    private AudioSource soundPlay;

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
        soundPlay = gameObject.AddComponent<AudioSource>();
        soundPlay.playOnAwake = true;

        switch (type)
        {
            case "crash":
                soundPlay.clip = crashSound;
                if (!soundPlay.isPlaying)
                {
                    soundPlay.Play();
                    Debug.Log("CRASH SOUND");
                }
                break;
            case "power":
                soundPlay.clip = powerSound;
                if (!soundPlay.isPlaying)
                {
                    soundPlay.Play();
                    Debug.Log("POWER SOUND");
                }
                break;
            default:
                // do nothing
                Debug.Log("NOTHING");
                break;
        }

        Destroy(soundPlay);
    }
}
