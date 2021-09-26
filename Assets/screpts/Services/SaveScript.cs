using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript 
{
    public static readonly string GameTypeKey = "GameType";
    public static readonly string GameDifficulty = "GameDifficulty";
    public static readonly string BestScoreKey = "BestScore";
    public static void StoreIntValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static int GetStoredInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
}
