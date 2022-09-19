using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetOnCollision : MonoBehaviour
{
    public string target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == target && other != null)
        {
            // Enemy destroyed only by laser
            if (other.tag == "Enemy" && gameObject.tag != "Collider")
            {
                other.gameObject.GetComponent<OnEnemyDestruction>().destruct();
            }
            // Boost destroyed only by vaisseau
            else if (other.tag == "Boost" && gameObject.tag != "Collider")
            {
                GetComponent<PlayerController>().boost();
                Destroy(other.gameObject);
            }
            // Call the player's destruct method to manage some other options
            else if (other.tag == "Player" && other.gameObject.name == "Vaisseau")
            {
                other.gameObject.GetComponent<PlayerController>().destruct();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
