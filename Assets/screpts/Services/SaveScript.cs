using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript 
{
    public static readonly string GameTypeKey = "GameType";
    public static readonly string GameDifficulty = "GameDifficulty";
    public static readonly string BestScoreKeyOne = "BestScoreTwo";
    public static readonly string BestScoreKeyThree = "BestScoreThree";
    public static readonly string BestScoreKeyFive = "BestScoreFive";
    public static void StoreIntValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static int GetStoredInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void SaveBestScore(int lvlDifficulty, int value)
    {
        switch (lvlDifficulty)
        {
            case (60):
                StoreIntValue(BestScoreKeyOne, value);
                break;
            case (180):
                StoreIntValue(BestScoreKeyThree, value);
                break;
            case (300):
                StoreIntValue(BestScoreKeyFive, value);
                break;
            default:
                break;
        }
    }   

    public static int GetBestScore(int lvlDifficulty)
    {
        int score = 0;

        switch (lvlDifficulty)
        {
            case (0):
                score = GetStoredInt(BestScoreKeyOne);
                break;
            case (1):
                score = GetStoredInt(BestScoreKeyThree);
                break;
            case (2):
                score = GetStoredInt(BestScoreKeyFive);
                break;
            default:
                break;
        }
        return score;
    }
}
