using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LevelJsonController : MonoBehaviour
{
    public int LevelNumb;
    public LevelScenario LevelScenarioCl;
    public int iter = 0;
    public string[] Instuction;
    public delegate void Insr(string Argument);
    public static event Insr Qestion;
    public static event Insr Image;
    public static event Insr Messege;

    void Start()
    {
        LevelScenarioCl = JsonUtility.FromJson<LevelScenario>(File.ReadAllText(Application.streamingAssetsPath+"/Level"+System.Convert.ToString(LevelNumb)+".json"));
    }

    [System.Serializable]
    public class LevelScenario
    {
        public List<string> Scenario;
        



    }
    public void next()
    {
        
        Instuction = LevelScenarioCl.Scenario[0].Split('/');
       switch(Instuction[0] )
        {
            case "1":
                Qestion(Instuction[1]);
                break;

            case "2":
                Messege(Instuction[1]);
                break;

            case "3":
                Image(Instuction[1]);
                break;

        }

        
    }
}
