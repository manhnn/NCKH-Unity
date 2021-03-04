using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfigs
{
    public static string LEVELKEY = "Level";

    public static string SFXVOLUMN = "SFXVolumn";

    public static string BFXVOLUMN = "BFXVolumn";


    public static int IntLevelKey
    {
        get => PlayerPrefs.GetInt(LEVELKEY, 1);
        set
        {
            if (value != 0)
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
            if (value >= 0 && value <= 1)
                PlayerPrefs.SetFloat(SFXVOLUMN, value);
            else
                Debug.LogError("PlayerPrefs Errors");
        }
    }

    public static float FloatBFXVolumn
    {
        get => PlayerPrefs.GetFloat(BFXVOLUMN, 0.5f);
        set
        {
            if (value >= 0 && value <= 1)
                PlayerPrefs.SetFloat(BFXVOLUMN, value);
            else
                Debug.LogError("PlayerPrefs Errors");
        }
    }
}
