﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public static HomeController instance = null;

    public static string SCENE_NAME = "Home";

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

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameController.SCENE_NAME);
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
