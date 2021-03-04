using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public static string SCENE_NAME = "Game";

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(HomeController.SCENE_NAME);
    }

    public void ReloadGameScene()
    {
        SceneManager.LoadScene(SCENE_NAME);
    }
    public void AddSettingScene()
    {
        SceneManager.LoadScene(SettingController.SCENE_NAME, LoadSceneMode.Additive);
    }

}
