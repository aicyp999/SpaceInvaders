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
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
