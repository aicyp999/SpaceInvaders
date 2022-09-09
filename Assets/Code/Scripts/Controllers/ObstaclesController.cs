using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public float obstacleSpeed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Vaisseau");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * obstacleSpeed);

        if (target)
        {
            Vector3 moveDir = (target.transform.position - transform.position).normalized;
            Debug.Log(target.name);
            Debug.Log(target.transform.position);
            transform.position += moveDir * Time.deltaTime * obstacleSpeed;
        }
    }
}
