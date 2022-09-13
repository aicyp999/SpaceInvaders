using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetOnCollision : MonoBehaviour
{
    public string target;

    private int numberOfHits = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == target && other != null)
        {
            numberOfHits--;
            // Enemy destroyed only by laser
            if (other.tag == "Enemy" && gameObject.tag != "Collider")
            {
                if (numberOfHits >= 0)
                {
                    other.gameObject.GetComponent<OnEnemyDestruction>().destruct();
                }
            } 
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
