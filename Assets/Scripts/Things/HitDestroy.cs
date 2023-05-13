using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnColliderEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("WindowTunel"));
        }
    }
}
