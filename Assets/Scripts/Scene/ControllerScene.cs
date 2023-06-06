using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControllerScene : MonoBehaviour
{
    public GameObject CanvasMenu;
    public GameObject CanvasDead;

    //Chung
    public void ExitToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        CanvasDead.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        CanvasMenu.SetActive(false);
    }
    //Riêng (các scene ở chế độ khác nhau)

    // Cốt truyện
    public void ReloadScene1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        CanvasDead.SetActive(false);
    }
    public void ReloadScene2()
    {
        SceneManager.LoadScene("Scene2");
        Time.timeScale = 1;
        CanvasDead.SetActive(false);
    }

    public void ReloadScene3()
    {
        SceneManager.LoadScene("Scene3");
        Time.timeScale = 1;
        CanvasDead.SetActive(false);
    }

    public void ReloadSceneTank90s()
    {
        SceneManager.LoadScene("Tank90s");
        Time.timeScale = 1;
        CanvasDead.SetActive(false);
    }
    // Easy Mode

    // Hard Mode
    
}
