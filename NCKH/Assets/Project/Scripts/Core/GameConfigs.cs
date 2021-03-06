using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfigs
{
    public static string LEVELKEY = "Level";

    public static string STARKEY = "Star";

    public static string SFXVOLUMN = "SFXVolumn";

    public static string BFXVOLUMN = "BFXVolumn";

    public static int IntStarKey
    {
        get => PlayerPrefs.GetInt(STARKEY, 1);
        set
        {
            if (value >= 0)
                PlayerPrefs.SetInt(STARKEY, value);
            else
                Debug.LogError("PlayerPrefs Errors");
        }
    }

    public static int IntLevelKey
    {
        get => PlayerPrefs.GetInt(LEVELKEY, 1);
        set
        {
            if (value >= 1)
                PlayerPrefs.SetInt(LEVELKEY, value);
            else
                Debug.LogError("PlayerPrefs Errors");
        }
    }

    public static float FloatSFXVolumn
    {
        get => PlayerPrefs.GetFloat(SFXVOLUMN, 0.5f);
        set
        {
            if (AudioController.instance != null)
            {
                if (value >= 0 && value <= 1)
                {
                    PlayerPrefs.SetFloat(SFXVOLUMN, value);
                    AudioController.instance.SetSFXVolumn();

                }
                else
                    Debug.LogError("PlayerPrefs Errors");
            }
            else
            {
                Debug.LogError("There is no AudioController");
            }
        }
    }

    public static float FloatBFXVolumn
    {
        get => PlayerPrefs.GetFloat(BFXVOLUMN, 0.5f);
        set
        {
            if (AudioController.instance != null)
            {
                if (value >= 0 && value <= 1)
                {
                    PlayerPrefs.SetFloat(BFXVOLUMN, value);
                    AudioController.instance.SetBFXVolumn();
                }
                else
                    Debug.LogError("PlayerPrefs Errors");
            }
            else
            {
                Debug.LogError("There is no AudioController");
            }
        }
    }
}
