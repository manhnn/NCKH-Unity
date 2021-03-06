using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSetting : MonoBehaviour
{
    public static EndSetting instance = null;

    public static string SCENE_NAME = "End";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene(HomeController.SCENE_NAME);
        Debug.Log("Home");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameController.SCENE_NAME);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
