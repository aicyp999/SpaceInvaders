using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetOnCollision : MonoBehaviour
{
    public string target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == target)
        {
            Debug.Log(other.tag);
            Destroy(other.gameObject);
        }
    }
}
