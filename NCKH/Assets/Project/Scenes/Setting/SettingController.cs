using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public static SettingController instance = null;
    [SerializeField] Slider _SFXSlider = null;
    [SerializeField] Slider _BFXSlider = null;

    public static string SCENE_NAME = "Setting";
    private void Awake()
    {
        _SFXSlider.value = GameConfigs.FloatSFXVolumn;
        _BFXSlider.value = GameConfigs.FloatBFXVolumn;
    }

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
    }
    public void SetBFX(float vol)
    {
        GameConfigs.FloatBFXVolumn = vol;
    }

}
