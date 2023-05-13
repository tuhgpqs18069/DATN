using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Destroy(GameObject.Find("Chair"));
        }
        if (collision.gameObject.tag == "elevator")
        {
            transform.parent = collision.gameObject.transform;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "elevator")
        {
            transform.parent = null;
        }
    }
}
