using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vaisseauSpeed;
    public bool controlWithMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movements
        if (controlWithMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
        } else
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * vaisseauSpeed);

            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * vertical * Time.deltaTime * vaisseauSpeed);
        }
    }
}
