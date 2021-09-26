using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private const string MainMenu = "VSTUPLENIE";
    private const string HubScene = "UROVNI";
    private const string GameScene = "GameScene";
    private const string GameSceneMulti = "GameScenóMulti"; 

    public static void NavigateMain()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public static void NavigateHub()
    {
        SceneManager.LoadScene(HubScene);
    }

    public static void NavigateGameScene()
    {
        SceneManager.LoadScene(GameScene);
    }

    public static void NavigateGameSceneMulti()
    {
        SceneManager.LoadScene(GameSceneMulti);
    }
}
