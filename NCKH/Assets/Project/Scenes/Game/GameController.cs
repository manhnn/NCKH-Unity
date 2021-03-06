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
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(EndSetting.SCENE_NAME);
    }

    public void ReloadGameScene()
    {
        SceneManager.LoadScene(SCENE_NAME);
    }
    public void AddSettingScene()
    {
        SceneManager.LoadScene(SettingController.SCENE_NAME, LoadSceneMode.Additive);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
