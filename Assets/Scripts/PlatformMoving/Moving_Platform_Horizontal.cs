using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_Horizontal : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveRight == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if(transform.position.x <= pointA.position.x)
        {
            moveRight = true;
        }
        if(transform.position.x >= pointB.position.x)
        {
            moveRight = false;
        }
    }

}
