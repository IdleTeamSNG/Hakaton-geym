using UnityEngine;
using UnityEngine.SceneManagement;

public  class Navigation : MonoBehaviour
{
    private const string MainMenu = "MainMenu";
    private const string HubScene = "UROVNI";
    private const string GameScene = "GameScene";
    private const string GameSceneMulti = "GameScenóMulti";
    private const string Settings = "settings";
    private const string Credits = "credits";
    private const string Ruls = "Ruls";
    private const string Players = "Players";

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

    public static void NavigateSettings()
    {
        SceneManager.LoadScene(Settings);
    }

    public static void NavigateCredits()
    {
        SceneManager.LoadScene(Credits);
    }
    public static void NavigateQuit()
    {
        Application.Quit();
    }
    public static void NavigateRuls()
    {
        SceneManager.LoadScene(Ruls);
    }
    public static void NavigatePlayers()
    {
        SceneManager.LoadScene(Players);
    }
}
