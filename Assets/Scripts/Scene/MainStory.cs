using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
        //SceneManager.LoadScene("Scene1");if (collision.gameObject.tag == "scene2")
         
    }
}
