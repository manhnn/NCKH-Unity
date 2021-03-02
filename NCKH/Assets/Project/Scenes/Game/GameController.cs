using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public static string SCENE_NAME = "Game";

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


}
