using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControllerScene : MonoBehaviour
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
        
        if (collision.gameObject.tag == "scene2")
        {
            SceneManager.LoadScene("Scene2");
        }

        if (collision.gameObject.tag == "scene3")
        {
            SceneManager.LoadScene("Scene3");
        }

       



    }
}
