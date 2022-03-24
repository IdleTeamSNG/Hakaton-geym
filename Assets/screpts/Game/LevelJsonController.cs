using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelJsonController : MonoBehaviour
{
    public int LevelNumb;
    public LevelScenario LevelScenarioCl;

    void Start()
    {
        LevelScenarioCl = JsonUtility.FromJson<LevelScenario>(File.ReadAllText(Application.streamingAssetsPath+"/Level"+System.Convert.ToString(LevelNumb)+".json"));
    }

    [System.Serializable]
    public class LevelScenario
    {
        public List<string> Scenario;
        



    }
}
