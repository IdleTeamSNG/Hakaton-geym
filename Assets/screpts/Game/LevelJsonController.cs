using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LevelJsonController : MonoBehaviour
{
    public int LevelNumb;
    public static LevelScenario LevelScenarioCl;
    public static int iter = 0;
    
    public delegate void Insr(string Argument);
    public static event Insr Qestion;
    public static event Insr Image;
    public static event Insr Messege;

    void Start()
    {
        LevelScenarioCl = JsonUtility.FromJson<LevelScenario>(File.ReadAllText(Application.streamingAssetsPath+"/Level"+System.Convert.ToString(LevelNumb)+".json"));
        NextQest();
    }

    [System.Serializable]
    public class LevelScenario
    {
        public List<string> Scenario;
        



    }
    public class ImageScenario
    {
        public List<string> Scenario;




    }
    public class StrScenario
    {
        public List<string> Scenario;




    }


    public static void NextQest()
    {
                
        Qestion?.Invoke(Argument: LevelScenarioCl.Scenario[iter]);
        iter++;

    }
        



    }

