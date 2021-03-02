using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public static HomeController instance = null;

    public static string SCENE_NAME = "Home";

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ReloadGameScene()
    {
        SceneManager.LoadScene(SCENE_NAME);
    }

    public void LoadGame(string name)
    {
        SceneManager.LoadScene(name);
    }

}
