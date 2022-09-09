using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject bg;
    public float speed;

    private Vector2 tmpPos;
    private GameObject bgInst;

    // Start is called before the first frame update
    void Start()
    {
        tmpPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bgInst)
        {
            bgInst = Instantiate(bg, transform.position, transform.rotation) as GameObject;
            Debug.Log("just spawned");
        } else
        {
            bgInst.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
