using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_Vertical : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public bool moveUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveUp == true)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if(transform.position.y <= pointA.position.y)
        {
            moveUp = true;
        }
        if(transform.position.y >= pointB.position.y)
        {
            moveUp = false;
        }
    }
}
