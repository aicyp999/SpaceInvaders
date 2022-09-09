using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay;
    public float magnitude = 1f;

    private float nextSpawnTime;
    private Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            float decalage = Random.Range(-magnitude, magnitude);

            Instantiate(prefab, initialPosition + Vector2.right * decalage, transform.rotation);
            nextSpawnTime = Time.time + spawnDelay;
        }
        
    }
}
