using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingController : MonoBehaviour
{
    public static SettingController instance = null;

    public static string SCENE_NAME = "Setting";

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(SettingController.SCENE_NAME);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameController.SCENE_NAME);
    }

    public void BackScene()
    {
        SceneManager.UnloadSceneAsync(SCENE_NAME);
    }

    public void SetSFX(float vol)
    {
        GameConfigs.FloatSFXVolumn = vol;
        Debug.Log(GameConfigs.FloatSFXVolumn);
    }
    public void SetBFX(float vol)
    {
        GameConfigs.FloatBFXVolumn = vol;
    }

}
