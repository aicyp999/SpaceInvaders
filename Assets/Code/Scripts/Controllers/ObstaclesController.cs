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

        if (target && target.transform.position.y < transform.position.y)
        {
            Vector3 moveDir = (target.transform.position - transform.position).normalized;
            transform.position += new Vector3(moveDir.x * Time.deltaTime * obstacleSpeed, 0, 0);
        }
    }
}
